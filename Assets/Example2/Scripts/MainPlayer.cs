using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
	[Tooltip("角色的移动速度可自己调整，封顶为100")]
	[Range(0f, 100f)]
	[SerializeField]
	private float moveSpeed;

	[Tooltip("角色的质量，值越大，移动速度越慢")]
	[Min(0f)]
	[SerializeField]
	private float mass;

	[Tooltip("角色的线性阻尼，值越大，移动阻力越大")]
	[Min(0f)]
	[SerializeField]
	private float drag;

	[Tooltip("角色的角阻尼，值越大，移动阻力越大")]
	[Min(0f)]
	[SerializeField]
	private float angularDrag;

	/// <summary>
	/// 角色的刚体组件。由于脚本类的三级父类Component中包含一个同名的、已弃用的变量rigidbody，在这里需要使用关键字new表示这是子类的新变量。如果你想起不一样的名字，例如rd，可以把new删掉。
	/// 在这个例子中，我将用代码为角色手动添加RigidBody2D组件。如果你想在编辑器中添加组件并手动修改数值，请注释掉void Start()中TO_COMMENT区域的所有代码。
	/// </summary>
	private new Rigidbody2D rigidbody;
	
	/// <summary>
	/// 角色的移动方向向量。这个变量将被键盘输入影响。
	/// </summary>
	private Vector2 moveDirection;

	/// <summary>
	/// 脚本的构造函数，用于设定默认值。请注意：不要在构造函数中使用GetComponent、AddComponent等方法或gameObject等属性。
	/// 如果你在构造函数中修改了数值，编辑器不会同步修改，这时点击脚本最右边的三个点->Reset(重置)。
	/// </summary>
	public MainPlayer()
	{
		moveSpeed = 12f;
		mass = 40f;
		drag = 20f;
		angularDrag = 20f;
		//Vector2.zero属性会返回一个零向量，相当于new Vector2(0f, 0f)。
		moveDirection = Vector2.zero;
	}

	void Start()
	{
		//尝试获取RigidBody2D组件。
		rigidbody = GetComponent<Rigidbody2D>();

		#region TO_COMMENT
		//如果组件未获取，则添加一个。
		if (!rigidbody)
		{
			//gameObject属性会返回当前脚本实例所附在的游戏物体引用。
			//在这个例子中，我只会将脚本挂载在场景中的Player上，因此gameObject会返回Player。（但是，如果将多个此脚本挂在了不同的游戏物体上，则每个gameObject属性都不尽相同。）
			rigidbody = gameObject.AddComponent<Rigidbody2D>();
		}
		rigidbody.mass = mass;
		rigidbody.drag = drag;
		rigidbody.angularDrag = angularDrag;
		#endregion
		//重力设为0，否则物体将会掉落。
		rigidbody.gravityScale = 0f;
	}

	/// <summary>
	/// 在这里，由于以后会写与碰撞相关的逻辑，我将使用FixedUpdate代替Update。
	/// </summary>
	void FixedUpdate()
	{
		//Input.GetAxis()传入一个字符串，内容为输入轴的名字。输入轴可以去Project Settings->Input Manager(输入管理器)->Axes(轴线)->任意一个轴->Name(名称)中查看。返回值是在这个轴上的输入值(有正负，正值为正方向移动，负值相反)。
		//将方向向量的x,y值设为这两个轴的输入值。
		moveDirection.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		//将向量单位化，以保证移动速度在数值上相等。
		moveDirection.Normalize();
		//magnitude返回这个向量的长度，即向量的模。
		//判断向量是否为零向量，如果不是，则对物体施加一个朝键盘输入方向的力。由于是浮点数的桎梏，不能直接判断是否等于0。
		if (moveDirection.magnitude > 0.1f)
		{
			//AddForce()传入两个参数，分别是向量值和力的施加方式。Impulse为瞬时冲击力，而Force为持续力。会根据向量的大小和方向对物体朝指定方向施加一个力使其运动。
			//将输入方向向量乘以移动速度使向量扩大，并选择施加瞬时力。
			rigidbody.AddForce(moveDirection * moveSpeed, ForceMode2D.Impulse);
		}
	}
}

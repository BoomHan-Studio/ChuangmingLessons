using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayer : MonoBehaviour
{
	[Tooltip("��ɫ���ƶ��ٶȿ��Լ��������ⶥΪ100")]
	[Range(0f, 100f)]
	[SerializeField]
	private float moveSpeed;

	[Tooltip("��ɫ��������ֵԽ���ƶ��ٶ�Խ��")]
	[Min(0f)]
	[SerializeField]
	private float mass;

	[Tooltip("��ɫ���������ᣬֵԽ���ƶ�����Խ��")]
	[Min(0f)]
	[SerializeField]
	private float drag;

	[Tooltip("��ɫ�Ľ����ᣬֵԽ���ƶ�����Խ��")]
	[Min(0f)]
	[SerializeField]
	private float angularDrag;

	/// <summary>
	/// ��ɫ�ĸ�����������ڽű������������Component�а���һ��ͬ���ġ������õı���rigidbody����������Ҫʹ�ùؼ���new��ʾ����������±��������������һ�������֣�����rd�����԰�newɾ����
	/// ����������У��ҽ��ô���Ϊ��ɫ�ֶ����RigidBody2D�������������ڱ༭�������������ֶ��޸���ֵ����ע�͵�void Start()��TO_COMMENT��������д��롣
	/// </summary>
	private new Rigidbody2D rigidbody;
	
	/// <summary>
	/// ��ɫ���ƶ������������������������������Ӱ�졣
	/// </summary>
	private Vector2 moveDirection;

	/// <summary>
	/// �ű��Ĺ��캯���������趨Ĭ��ֵ����ע�⣺��Ҫ�ڹ��캯����ʹ��GetComponent��AddComponent�ȷ�����gameObject�����ԡ�
	/// ������ڹ��캯�����޸�����ֵ���༭������ͬ���޸ģ���ʱ����ű����ұߵ�������->Reset(����)��
	/// </summary>
	public MainPlayer()
	{
		moveSpeed = 12f;
		mass = 40f;
		drag = 20f;
		angularDrag = 20f;
		//Vector2.zero���Ի᷵��һ�����������൱��new Vector2(0f, 0f)��
		moveDirection = Vector2.zero;
	}

	void Start()
	{
		//���Ի�ȡRigidBody2D�����
		rigidbody = GetComponent<Rigidbody2D>();

		#region TO_COMMENT
		//������δ��ȡ�������һ����
		if (!rigidbody)
		{
			//gameObject���Ի᷵�ص�ǰ�ű�ʵ�������ڵ���Ϸ�������á�
			//����������У���ֻ�Ὣ�ű������ڳ����е�Player�ϣ����gameObject�᷵��Player�������ǣ����������˽ű������˲�ͬ����Ϸ�����ϣ���ÿ��gameObject���Զ�������ͬ����
			rigidbody = gameObject.AddComponent<Rigidbody2D>();
		}
		rigidbody.mass = mass;
		rigidbody.drag = drag;
		rigidbody.angularDrag = angularDrag;
		#endregion
		//������Ϊ0���������彫����䡣
		rigidbody.gravityScale = 0f;
	}

	/// <summary>
	/// ����������Ժ��д����ײ��ص��߼����ҽ�ʹ��FixedUpdate����Update��
	/// </summary>
	void FixedUpdate()
	{
		//Input.GetAxis()����һ���ַ���������Ϊ����������֡����������ȥProject Settings->Input Manager(���������)->Axes(����)->����һ����->Name(����)�в鿴������ֵ����������ϵ�����ֵ(����������ֵΪ�������ƶ�����ֵ�෴)��
		//������������x,yֵ��Ϊ�������������ֵ��
		moveDirection.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		//��������λ�����Ա�֤�ƶ��ٶ�����ֵ����ȡ�
		moveDirection.Normalize();
		//magnitude������������ĳ��ȣ���������ģ��
		//�ж������Ƿ�Ϊ��������������ǣ��������ʩ��һ�����������뷽������������Ǹ�����������������ֱ���ж��Ƿ����0��
		if (moveDirection.magnitude > 0.1f)
		{
			//AddForce()���������������ֱ�������ֵ������ʩ�ӷ�ʽ��ImpulseΪ˲ʱ���������ForceΪ������������������Ĵ�С�ͷ�������峯ָ������ʩ��һ����ʹ���˶���
			//�����뷽�����������ƶ��ٶ�ʹ�������󣬲�ѡ��ʩ��˲ʱ����
			rigidbody.AddForce(moveDirection * moveSpeed, ForceMode2D.Impulse);
		}
	}
}

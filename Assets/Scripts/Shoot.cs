using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour
{
	private Transform _transform;
	public GameObject bullet;

	public float bulletSpeed = 25f;

	public float fireRate = 0.15f;
	private float _fireTimer = 0f;
	private bool _side = false;

	private Vector3 _gunOffset;

	void Awake()
	{
		_transform = transform;

		_gunOffset = -_transform.up;
	}

	void Update()
	{
		_fireTimer += Time.deltaTime;
		if( Input.GetMouseButton(0) )
		{
			if( _fireTimer >= fireRate )
			{
				_fireTimer = 0f;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				Quaternion look = Quaternion.LookRotation(ray.direction);
				//Vector3 pt = _transform.position + _gunOffset + _transform.right * ( _side ? -0.75f : 0.75f );
				Vector3 pt = _transform.position + _gunOffset ;
				GameObject obj = GameObject.Instantiate(bullet, pt, look) as GameObject;
				Bullet b = obj.GetComponent<Bullet>();
				b.speed = bulletSpeed;

				_side = !_side;
			}
		}
	}
}

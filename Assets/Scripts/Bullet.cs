using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public GameObject impact;

	private Transform _transform;
	private float _speed;
	private Vector3 _lastPosition;

	private float _aliveTime = 5f;
	private float _timer = 0f;

	private int _layerMask = -1;

	void Awake()
	{
		_timer = 0f;
		_transform = transform;
		_lastPosition = _transform.position;

		//_layerMask = LayerMask.NameToLayer("Environment") | LayerMask.NameToLayer("Enemy");
		//_layerMask = ~LayerMask.NameToLayer("Event");

		_layerMask = ( 1 << 8 ) | ( 1 << 10 );
		Debug.Log("bullet layermask: " + _layerMask);
	}

	void Update () {
		float dist = Vector3.Distance(_transform.position, _lastPosition);
		Vector3 dir = Vector3.Normalize(_transform.position - _lastPosition);

		Debug.DrawRay(_transform.position, dir * dist, Color.red);
		RaycastHit[] hits = Physics.RaycastAll(_transform.position, dir, dist, _layerMask);
		for(int i=0; i< hits.Length; i++)
		{
			if( hits[i].transform.CompareTag("Enemy") )
				hits[i].transform.SendMessage("Shot");

			Asplode(hits[i]);
		}

		_lastPosition = _transform.position;
		_transform.position = _transform.forward * speed * Time.deltaTime + _transform.position;

		_timer += Time.deltaTime;
		if( _timer >= _aliveTime )
			Asplode();
	}

	protected void Asplode(RaycastHit hit)
	{
		Instantiate(impact, hit.point, Quaternion.LookRotation( hit.normal));
		Destroy(gameObject);
	}

	protected void Asplode()
	{
		Destroy(gameObject);
	}

	public float speed
	{
		get { return _speed; }
		set { _speed = value; }
	}
}

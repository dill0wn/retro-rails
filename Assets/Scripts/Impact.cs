using UnityEngine;
using System.Collections;

public class Impact : MonoBehaviour {

	private float _aliveTime = 0.5f;
	private float _timer = 0f;
	
	// Update is called once per frame
	void FixedUpdate () {
		_timer += Time.deltaTime;
		if( _timer >= _aliveTime )
			Asplode();
	}

	public void Asplode()
	{
		Destroy(gameObject);
	}

}

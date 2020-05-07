using UnityEngine;

public class MyBezier : MonoBehaviour
{
	public Bezier myBezier;
	private float t = 0f;

	private LineRenderer curve;

	void Start()
	{
		myBezier = new Bezier( new Vector3( -5f, 0f, 0f ), Random.insideUnitSphere * 2f, Random.insideUnitSphere * 2f, new Vector3( 5f, 0f, 0f ) );
		curve = gameObject.AddComponent<LineRenderer>();

		int count = 1;
		for( float i = 0f; i < 1f; i += 0.01f )
		{
			curve.SetVertexCount( count );
			curve.SetPosition( count - 1, myBezier.GetPointAtTime( i ) );
			count++;
		}

	}

	void Update()
	{
		Vector3 vec = myBezier.GetPointAtTime( t );
		transform.position = vec;

		t += 0.001f;
		if( t > 1f )
			t = 0f;
	}
}
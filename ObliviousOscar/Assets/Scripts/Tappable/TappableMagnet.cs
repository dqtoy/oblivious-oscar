using UnityEngine;

public class TappableMagnet : Tappable
{
	public bool tappableTwice;
	public float initDistance;
	public bool isActivated;
	DistanceJoint2D dj;

	void Start ()
	{
		dj = GetComponent<DistanceJoint2D> ();
	}

	public override void OnTap ()
	{
		if (!isActivated) {
			dj.distance = 0;
			isActivated = true;
		} else if (tappableTwice) {
			dj.distance = initDistance;
			isActivated = false;
		}
	}
	
}

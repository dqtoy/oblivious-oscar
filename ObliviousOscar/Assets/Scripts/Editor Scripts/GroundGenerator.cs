﻿#if UNITY_EDITOR	

using UnityEngine;
using UnityEditor;

[ExecuteInEditMode]
public class GroundGenerator : MonoBehaviour
{
	public bool generateGround = false;
	public GameObject groundPrefab;

	void Update ()
	{
		if (EditorApplication.isPlaying) {
			return;
		}

		Transform groundContainer = transform;

		if (generateGround) {
			generateGround = false;

			Transform rightMost = null;

			foreach (var t in groundContainer.GetComponentsInChildren<Transform> ()) {
				if (rightMost == null || t.position.x > rightMost.position.x) {
					rightMost = t;
				}
			}

			var generated = PrefabUtility.InstantiatePrefab (groundPrefab) as GameObject;
			generated.transform.SetParent (groundContainer);
			generated.transform.position = new Vector3 (rightMost.position.x + Offset (), groundContainer.position.y);
		}
	}

	float Offset ()
	{
		return groundPrefab.GetComponent<SpriteRenderer> ().sprite.bounds.extents.x * 2;
	}
}

#else

public class GroundGenerator : UnityEngine.MonoBehaviour
{
}

#endif
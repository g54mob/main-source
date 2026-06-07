using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class OcclusionOverlapChecker : MonoBehaviour
	{
		public LayerMask layerMask;

		public Transform start;

		public Transform end;

		public float checkRate;

		private float _time;

		private CapsuleCollider _capsule;

		private List<GameObject> _hiddenObjects;

		private List<GameObject> _stillHiddenObjects;

		private List<GameObject> _overlappingObjects;

		private Collider[] _overlapColliders;

		private void Start()
		{
		}

		private void OnResetUI(object sender, EventArgs e)
		{
		}

		private void Update()
		{
		}

		private void CheckOverlap()
		{
		}

		private void SetVisibility(bool isVisible, GameObject go)
		{
		}

		private void CleanUp()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}
	}
}

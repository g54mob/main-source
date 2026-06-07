using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Environment.Vegetation
{
	public class TreeColliderData : MonoBehaviour
	{
		[SerializeField]
		private Vector3 _center;

		[SerializeField]
		private float _height;

		[SerializeField]
		private float _radius;

		public Vector3 Center => _center;

		public float Height => _height;

		public float Radius => _radius;

		protected virtual void OnDrawGizmosSelected()
		{
			GizmosUtility.DrawWireCapsule(_center, _height, _radius, Vector3.up, Color.green, base.transform.localToWorldMatrix);
		}
	}
}

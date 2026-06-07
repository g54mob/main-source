using Jundroo.Common.Extensions;
using UnityEngine;

namespace Assets.Scripts.Flight.Discoverables
{
	public class AreaNameScript : MonoBehaviour
	{
		[SerializeField]
		private string _areaName;

		[SerializeField]
		private float _areaSize = 1000f;

		[SerializeField]
		private bool _ignoreYAxis = true;

		public string AreaName
		{
			get
			{
				return _areaName;
			}
			set
			{
				_areaName = value;
			}
		}

		public float AreaSize => _areaSize;

		public bool IgnoreYAxis => _ignoreYAxis;

		public static string FindClosestAreaName(Vector3 position, bool mustBeWithinArea)
		{
			string result = null;
			float num = float.MaxValue;
			AreaNameScript[] array = Object.FindObjectsByType<AreaNameScript>(FindObjectsSortMode.None);
			foreach (AreaNameScript areaNameScript in array)
			{
				Vector3 vector;
				if (!areaNameScript.IgnoreYAxis)
				{
					vector = areaNameScript.transform.position;
				}
				else
				{
					Vector3 position2 = areaNameScript.transform.position;
					float? y = position.y;
					vector = position2.Copy(null, y);
				}
				Vector3 vector2 = vector;
				float sqrMagnitude = (position - vector2).sqrMagnitude;
				if (sqrMagnitude < num && (!mustBeWithinArea || sqrMagnitude < areaNameScript.AreaSize * areaNameScript.AreaSize))
				{
					result = areaNameScript.AreaName;
					num = sqrMagnitude;
				}
			}
			return result;
		}

		public bool IsInArea(Vector3 position)
		{
			Vector3 vector;
			if (!IgnoreYAxis)
			{
				vector = base.transform.position;
			}
			else
			{
				Vector3 position2 = base.transform.position;
				float? y = position.y;
				vector = position2.Copy(null, y);
			}
			Vector3 vector2 = vector;
			return (position - vector2).sqrMagnitude <= AreaSize * AreaSize;
		}

		protected virtual void OnDrawGizmosSelected()
		{
			if (!Application.isPlaying)
			{
				Gizmos.color = Color.white;
				Gizmos.DrawWireSphere(base.transform.position, AreaSize);
			}
		}
	}
}

using UnityEngine;

namespace Lean.Common
{
	[HelpURL("https://carloswilkes.com/Documentation/LeanCommon#LeanSpawn")]
	[AddComponentMenu("Lean/Common/Lean Spawn")]
	public class LeanSpawn : MonoBehaviour
	{
		public enum SourceType
		{
			ThisTransform = 0,
			Prefab = 1
		}

		[SerializeField]
		private Transform prefab;

		[SerializeField]
		private SourceType defaultPosition;

		[SerializeField]
		private SourceType defaultRotation;

		public Transform Prefab
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SourceType DefaultPosition
		{
			get
			{
				return default(SourceType);
			}
			set
			{
			}
		}

		public SourceType DefaultRotation
		{
			get
			{
				return default(SourceType);
			}
			set
			{
			}
		}

		public void Spawn()
		{
		}

		public void Spawn(Vector3 position)
		{
		}
	}
}

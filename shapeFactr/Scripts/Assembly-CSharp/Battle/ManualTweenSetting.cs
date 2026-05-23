using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Battle
{
	public class ManualTweenSetting : MonoBehaviour
	{
		private Sequence sequence;

		[Header("編集するときにのみONにする")]
		public bool editMode;

		public float duration;

		public PathType pathType;

		public Ease ease;

		public List<Vector3> wayPoint;

		public eLookAtType lookAtType;

		[Header("eLookAtTypeがTargetの時に有効")]
		public Transform lookPosition;

		private void Start()
		{
		}

		private void Update()
		{
		}

		private Tween CreateTweenPath()
		{
			return null;
		}
	}
}

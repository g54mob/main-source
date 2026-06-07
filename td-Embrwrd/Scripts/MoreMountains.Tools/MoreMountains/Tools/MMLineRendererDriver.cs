using System.Collections.Generic;
using UnityEngine;

namespace MoreMountains.Tools
{
	[RequireComponent(typeof(LineRenderer))]
	public class MMLineRendererDriver : MonoBehaviour
	{
		[Header("Position Drivers")]
		public List<Transform> Targets;

		public bool BindPositionsToTargetsAtUpdate;

		[MMInspectorButton("Bind")]
		[Header("Binding")]
		public bool BindButton;

		protected LineRenderer _lineRenderer;

		protected bool _countsMatch;

		protected virtual void Awake()
		{
		}

		protected virtual void Initialization()
		{
		}

		protected virtual void Update()
		{
		}

		protected virtual void Bind()
		{
		}

		public virtual void BindPositionsToTargets()
		{
		}

		protected virtual bool CheckPositionCounts()
		{
			return false;
		}
	}
}

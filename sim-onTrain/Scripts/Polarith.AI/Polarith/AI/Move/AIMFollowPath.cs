using System;
using System.Collections.Generic;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class AIMFollowPath : AIMSteeringBehaviour
	{
		[Tooltip("Allows to specify the settings of this behaviour.")]
		public Follow Follow = new Follow();

		[Tooltip("List of points which have to be sampled and followed.")]
		protected IList<Vector3> points = new List<Vector3>();

		[Tooltip("Used for providing the path.")]
		[SerializeField]
		protected AIMPathConnector pathConnector;

		protected Vector3 target;

		[Tooltip("Determines if the target is visualized or not.")]
		[SerializeField]
		protected bool enableVisualization = true;

		[Tooltip("Determines the color which is used for visualizing the target.")]
		[SerializeField]
		protected Color targetColor = Color.cyan;

		private AIMPathConnector oldPathConnector;

		public override SteeringBehaviour SteeringBehaviour => Follow;

		public Vector3 Target => target;

		public virtual AIMPathConnector PathConnector
		{
			get
			{
				return pathConnector;
			}
			set
			{
				pathConnector = value;
				points = pathConnector.GetPoints();
			}
		}

		public virtual IList<Vector3> Points
		{
			get
			{
				return new List<Vector3>(points);
			}
			set
			{
				if (!(pathConnector != null) && value != null)
				{
					Collections.ResizeList(points, value.Count);
					for (int i = 0; i < points.Count; i++)
					{
						points[i] = value[i];
					}
				}
			}
		}

		public override void PrepareEvaluation()
		{
			if (FilteredEnvironments.Count != 0)
			{
				FilteredEnvironments.Clear();
			}
			if (GameObjects.Count != 1 || GameObjects[0] != null)
			{
				GameObjects.Clear();
				GameObjects.Add(null);
			}
			base.PrepareEvaluation();
			if (pathConnector != oldPathConnector)
			{
				oldPathConnector = pathConnector;
				if (pathConnector == null)
				{
					points.Clear();
				}
				else
				{
					pathConnector.GetPointsNonAlloc(points);
				}
			}
			if (points.Count == 0)
			{
				Follow.Enabled = false;
				return;
			}
			Follow.Enabled = base.enabled;
			target = GetTarget();
			PerceptBehaviour.Percepts[0].Position = target;
			PerceptBehaviour.Percepts[0].Active = true;
			PerceptBehaviour.Percepts[0].Significance = 1f;
		}

		protected abstract Vector3 GetTarget();

		protected virtual void OnPathChange()
		{
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			if (pathConnector != null)
			{
				AIMPathConnector aIMPathConnector = pathConnector;
				aIMPathConnector.PathChanged = (Action)Delegate.Combine(aIMPathConnector.PathChanged, new Action(OnPathChange));
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (pathConnector != null)
			{
				AIMPathConnector aIMPathConnector = pathConnector;
				aIMPathConnector.PathChanged = (Action)Delegate.Remove(aIMPathConnector.PathChanged, new Action(OnPathChange));
			}
		}

		protected override void OnDrawGizmos()
		{
			base.OnDrawGizmos();
			if (enableVisualization)
			{
				Gizmos.color = targetColor;
				Gizmos.DrawSphere(target, 0.2f);
			}
		}

		private void Start()
		{
			if (pathConnector != null)
			{
				points = pathConnector.GetPoints();
			}
		}
	}
}

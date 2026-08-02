using System.Collections.Generic;
using Polarith.UnityUtils;
using Polarith.Utils;
using UnityEngine;

namespace Polarith.AI.Move
{
	[AddComponentMenu("Polarith AI » Move/Perception/AIM Steering Perceiver")]
	[HelpURL("http://docs.polarith.com/ai/component-aim-steeringperceiver.html")]
	public sealed class AIMSteeringPerceiver : AIMPerceiver<SteeringPercept>
	{
		[Tooltip("Defines the method of spatial partitioning to be used for optimizing the performance while accessing percept data. If 'None' is set, there is no structure to accelerate percept queries. Then, every agent with an 'AIM Steering Filter' iterates over all percepts and perform a simple distance check. Every other value corresponds to a specific structure for optimizing spatial access times significantly. This is especially useful for larger scenes having a lot of AI-relevant objects.")]
		public SpatialPartitionType SpatialPartition;

		[Tooltip("A structure used to perform spatial hashing for optimizing access to percept data. The grid can be adapted to the scene as necessary both for 2D or 3D. All percepts within the boundaries of the grid are processed. Note, this structure performs best if the scene contains a huge amount of objects that are more or less equally distributed in the scene. The perfect resolution of the grid dependents on the actual distribution and the level structure.")]
		public RegularGrid RegularGrid = new RegularGrid();

		[HideInInspector]
		[SerializeField]
		private bool environmentFoldout;

		[SerializeField]
		[HideInInspector]
		private TabState tabState;

		private SpatialPartitionType oldSpatialPartition;

		public void Awake()
		{
			SpatialPartitionType spatialPartition = SpatialPartition;
			if (spatialPartition != SpatialPartitionType.None && spatialPartition == SpatialPartitionType.RegularGrid)
			{
				RegularGrid.Initialize(Environments);
			}
		}

		public void GetPerceptsInRange(Vector3 point, float range, IList<string> environments, IList<SteeringPercept> percepts)
		{
			if (percepts.Count == 0)
			{
				return;
			}
			switch (SpatialPartition)
			{
			case SpatialPartitionType.None:
			{
				int num = 0;
				float num2 = ((range < 0f) ? (-1f) : (range * range));
				for (int i = 0; i < environments.Count; i++)
				{
					if (!Percepts.TryGetValue(environments[i], out var value))
					{
						continue;
					}
					if (num2 < 0f)
					{
						for (int j = 0; j < value.Count; j++)
						{
							SteeringPercept steeringPercept = (percepts[num + j] = value[j]);
							if (!steeringPercept.Received)
							{
								steeringPercept.Receive();
								steeringPercept.Received = true;
							}
						}
						num += value.Count;
						continue;
					}
					for (int k = 0; k < value.Count; k++)
					{
						SteeringPercept steeringPercept = value[k];
						if ((steeringPercept.Position - point).sqrMagnitude > num2)
						{
							percepts[num + k] = null;
							continue;
						}
						percepts[num + k] = steeringPercept;
						if (!steeringPercept.Received)
						{
							steeringPercept.Receive();
							steeringPercept.Received = true;
						}
					}
					num += value.Count;
				}
				break;
			}
			case SpatialPartitionType.RegularGrid:
				RegularGrid.Query(point, range, environments, percepts);
				break;
			}
		}

		protected override void PerceiveEnvironment(AIMEnvironment environment, IList<SteeringPercept> percepts)
		{
			Collections.ResizeList(percepts, environment.LayerGameObjects.Count + environment.GameObjects.Count);
			if (oldSpatialPartition != SpatialPartition)
			{
				Awake();
			}
			oldSpatialPartition = SpatialPartition;
			switch (SpatialPartition)
			{
			case SpatialPartitionType.None:
			{
				for (int i = 0; i < environment.LayerGameObjects.Count; i++)
				{
					if (environment.LayerGameObjects[i] != null)
					{
						percepts[i].Position = environment.LayerGameObjects[i].transform.position;
					}
					percepts[i].Received = false;
					percepts[i].SetGameObject(environment.LayerGameObjects[i]);
				}
				for (int j = 0; j < environment.GameObjects.Count; j++)
				{
					if (environment.GameObjects[j] != null)
					{
						percepts[environment.LayerGameObjects.Count].Position = environment.GameObjects[j].transform.position;
					}
					percepts[environment.LayerGameObjects.Count + j].Received = false;
					percepts[environment.LayerGameObjects.Count + j].SetGameObject(environment.GameObjects[j]);
				}
				break;
			}
			case SpatialPartitionType.RegularGrid:
				RegularGrid.Update(environment, percepts);
				break;
			}
		}

		protected override void StartPerceiving()
		{
			base.StartPerceiving();
			RegularGrid.PrepareUpdate(base.transform.position, Environments);
		}

		private void OnDrawGizmos()
		{
			SpatialPartitionType spatialPartition = SpatialPartition;
			if (spatialPartition != SpatialPartitionType.None && spatialPartition == SpatialPartitionType.RegularGrid)
			{
				RegularGrid.DrawGizmo(base.transform.position);
			}
		}
	}
}

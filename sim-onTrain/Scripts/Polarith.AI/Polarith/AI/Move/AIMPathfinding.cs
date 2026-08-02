using System.Collections.Generic;
using Polarith.UnityUtils;
using UnityEngine;

namespace Polarith.AI.Move
{
	public abstract class AIMPathfinding : AIMPathConnector
	{
		protected Vector3 destination;

		[Tooltip("This game object determines the destination of the path to be calculated.")]
		[SerializeField]
		protected GameObject destinationGameObject;

		protected List<Validator> validators = new List<Validator>();

		[Tooltip("Verifies the distance between the agent and the path.")]
		[SerializeField]
		protected DistanceValidator distanceValidator = new DistanceValidator();

		[Tooltip("Verifies if the target has moved")]
		[SerializeField]
		protected TargetValidator targetValidator = new TargetValidator();

		[Tooltip("Verifies if a set time has elapsed.")]
		[SerializeField]
		protected TimeValidator timeValidator = new TimeValidator();

		private int currentEdgeIndex = -1;

		[SerializeField]
		[HideInInspector]
		private bool validatorFoldout;

		public Vector3 Destination
		{
			get
			{
				return destination;
			}
			set
			{
				destination = value;
				CalculatePath(destination);
			}
		}

		public GameObject DestinationGameObject
		{
			get
			{
				return destinationGameObject;
			}
			set
			{
				destinationGameObject = value;
				Destination = destinationGameObject.transform.position;
			}
		}

		public DistanceValidator DistanceValidator => distanceValidator;

		public TargetValidator TargetValidator => targetValidator;

		public TimeValidator TimeValidator => timeValidator;

		public abstract void CalculatePath(Vector3 destination);

		protected virtual void Start()
		{
			validators.Clear();
			validators.Add(distanceValidator);
			validators.Add(timeValidator);
			validators.Add(targetValidator);
		}

		protected virtual void Update()
		{
			if (destinationGameObject != null)
			{
				destination = destinationGameObject.transform.position;
			}
			UpdateValidators();
			foreach (Validator validator in validators)
			{
				if (validator.Enabled && !validator.Validate())
				{
					CalculatePath(destination);
					break;
				}
			}
		}

		protected virtual void UpdateValidators()
		{
			currentEdgeIndex = Mathv.GetNearestEdge(GetPoints(), base.transform.position, distanceValidator.MaxDistance);
			distanceValidator.EdgeIndex = currentEdgeIndex;
			distanceValidator.Position = base.transform.position;
			if (distanceValidator.Enabled && distanceValidator.PathPoints == null)
			{
				distanceValidator.Enabled = false;
				Debug.LogWarning("(" + typeof(AIMPathfinding).Name + ") " + base.gameObject.name + ": disabled the distance validator because there is no reference to path points set");
			}
			if (destinationGameObject != null)
			{
				targetValidator.Target = destinationGameObject;
			}
			else
			{
				targetValidator.Enabled = false;
			}
		}
	}
}

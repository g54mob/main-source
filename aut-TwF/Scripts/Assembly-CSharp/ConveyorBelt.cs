using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(StatsComponent))]
public class ConveyorBelt : GameplayObject
{
	private const float AUX_SPEED = 0.025f;

	[SerializeField]
	private Renderer beltRenderer;

	[SerializeField]
	private EOrientation inputOrientation;

	[SerializeField]
	private EOrientation outputOrientation;

	[SerializeField]
	private float height = 1f;

	private float speed;

	private float rotationY;

	private ConveyorBeltGroup currentBeltGroup;

	private PlacementComponent placementComponent;

	private StatsComponent statsComponent;

	private GameplayEffectsComponent gameplayEffectsComponent;

	protected bool updateNearbyConveyorsOnUnplace = true;

	public EOrientation InputOrientation
	{
		get
		{
			return inputOrientation;
		}
		protected set
		{
			inputOrientation = value;
		}
	}

	public EOrientation OutputOrientation
	{
		get
		{
			return outputOrientation;
		}
		protected set
		{
			outputOrientation = value;
		}
	}

	public float Height
	{
		get
		{
			return height;
		}
		set
		{
			height = value;
		}
	}

	public virtual ConveyorBeltGroup CurrentBeltGroup
	{
		get
		{
			return currentBeltGroup;
		}
		set
		{
			currentBeltGroup = value;
		}
	}

	public PlacementComponent PlacementComponent
	{
		get
		{
			return placementComponent;
		}
		private set
		{
			placementComponent = value;
		}
	}

	public StatsComponent StatsComponent
	{
		get
		{
			return statsComponent;
		}
		set
		{
			statsComponent = value;
		}
	}

	public GameplayEffectsComponent GameplayEffectsComponent => gameplayEffectsComponent;

	public float Speed
	{
		get
		{
			return speed + 0.025f;
		}
		set
		{
			float num = speed;
			speed = value;
			if (beltRenderer != null)
			{
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				beltRenderer.GetPropertyBlock(materialPropertyBlock);
				float value2 = Mathf.Repeat(materialPropertyBlock.GetFloat("_Phase") + (num - speed) * Time.time, 1f);
				materialPropertyBlock.SetFloat("_Speed", speed);
				materialPropertyBlock.SetFloat("_Phase", value2);
				beltRenderer.SetPropertyBlock(materialPropertyBlock);
			}
		}
	}

	protected float RotationY
	{
		get
		{
			return rotationY;
		}
		set
		{
			rotationY = value;
		}
	}

	public virtual void Awake()
	{
		PlacementComponent = GetComponentInParent<PlacementComponent>();
		statsComponent = GetComponent<StatsComponent>();
		gameplayEffectsComponent = GetComponent<GameplayEffectsComponent>();
	}

	public virtual void Start()
	{
		PlacementComponent.onPlace += OnPlace;
		PlacementComponent.onUnplace += OnUnplace;
		PlacementComponent.onChangePosition += OnChangePosition;
		statsComponent.onStatChanged += onStatChanged;
		Speed = statsComponent.GetStat(EStats.Speed);
		if (PlacementComponent.IsPlaced)
		{
			OnPlace(PlacementComponent);
		}
	}

	public virtual float MovePosition(GameObject objectToMove, ref float maxDistance, ref float alreadyMovedTime)
	{
		return 0f;
	}

	protected virtual float GetDistanceFromEnd(Vector3 position)
	{
		return 0f;
	}

	public virtual float GetBeltDistance()
	{
		return 0f;
	}

	public virtual Vector3 GetStartPosition()
	{
		return base.transform.position + Vector3.up * Height + LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.OrientationToWorldSpace(InputOrientation, RotationY)) * 0.5f;
	}

	public virtual Vector3 GetEndPosition()
	{
		return base.transform.position + Vector3.up * Height + LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.OrientationToWorldSpace(OutputOrientation, RotationY)) * 0.5f;
	}

	protected virtual void UpdateConveyorBeltType()
	{
	}

	protected virtual bool ShowInputOrientation()
	{
		return true;
	}

	protected virtual bool ShowOutputOrientation()
	{
		return true;
	}

	protected virtual bool ShowSpeed()
	{
		return true;
	}

	public void ForceCallUnplace()
	{
		OnUnplace(PlacementComponent);
	}

	private void onStatChanged(EStats stat, float newValue, float oldValue)
	{
		if (stat == EStats.Speed)
		{
			Speed = newValue;
		}
	}

	protected virtual void OnPlace(PlacementComponent placementComponent)
	{
		bool flag = false;
		bool flag2 = false;
		foreach (ConveyorBelt adjacentBuiltObject in LTFunctionLibrary.GetGrid().GetAdjacentBuiltObjects<ConveyorBelt>(base.transform))
		{
			flag = false;
			flag2 = false;
			if (adjacentBuiltObject.CurrentBeltGroup == null)
			{
				continue;
			}
			if (LTFunctionLibrary.GetOrientationDot(LTFunctionLibrary.OrientationToWorldSpace(OutputOrientation, base.transform), LTFunctionLibrary.GetOrientationBetweenPositions(base.transform.position, adjacentBuiltObject.transform.position)) == 1f)
			{
				adjacentBuiltObject.UpdateConveyorBeltType();
			}
			if (LTFunctionLibrary.GetOrientationDot(LTFunctionLibrary.OrientationToWorldSpace(OutputOrientation, base.transform), LTFunctionLibrary.GetOrientationBetweenPositions(base.transform.position, adjacentBuiltObject.transform.position)) == 1f && LTFunctionLibrary.GetOrientationDot(LTFunctionLibrary.OrientationToWorldSpace(adjacentBuiltObject.InputOrientation, adjacentBuiltObject.transform), LTFunctionLibrary.GetOrientationBetweenPositions(base.transform.position, adjacentBuiltObject.transform.position)) == -1f)
			{
				flag = true;
				flag2 = true;
			}
			else if (LTFunctionLibrary.GetOrientationDot(LTFunctionLibrary.OrientationToWorldSpace(InputOrientation, base.transform), LTFunctionLibrary.GetOrientationBetweenPositions(base.transform.position, adjacentBuiltObject.transform.position)) == 1f && LTFunctionLibrary.GetOrientationDot(LTFunctionLibrary.OrientationToWorldSpace(adjacentBuiltObject.OutputOrientation, adjacentBuiltObject.transform), LTFunctionLibrary.GetOrientationBetweenPositions(base.transform.position, adjacentBuiltObject.transform.position)) == -1f)
			{
				flag = true;
				flag2 = false;
			}
			if (flag)
			{
				if (currentBeltGroup == null)
				{
					adjacentBuiltObject.CurrentBeltGroup.AddBelts(new List<ConveyorBelt> { this }, flag2);
				}
				else if (currentBeltGroup == adjacentBuiltObject.CurrentBeltGroup)
				{
					currentBeltGroup.IsLoop = true;
				}
				else if (flag2)
				{
					ConveyorBeltSystem.instance.MergeConveyorBeltGroups(currentBeltGroup, adjacentBuiltObject.currentBeltGroup);
				}
				else
				{
					ConveyorBeltSystem.instance.MergeConveyorBeltGroups(adjacentBuiltObject.currentBeltGroup, currentBeltGroup);
				}
			}
		}
		if (CurrentBeltGroup == null)
		{
			ConveyorBeltSystem.instance.CreateConveyorBeltGroup(new List<ConveyorBelt> { this }, null);
		}
		RotationY = base.transform.rotation.eulerAngles.y;
		UpdateConveyorBeltType();
	}

	protected virtual void OnUnplace(PlacementComponent placementComponent)
	{
		CurrentBeltGroup.GatherResourcesOnBelt(this);
		int beltIndex = CurrentBeltGroup.GetBeltIndex(this);
		if (beltIndex == 0)
		{
			CurrentBeltGroup.IsLoop = false;
			CurrentBeltGroup.RemoveFirstBelt(removeResources: true, recalculateDistances: true);
		}
		else if (beltIndex == CurrentBeltGroup.Belts.Count - 1)
		{
			CurrentBeltGroup.IsLoop = false;
			CurrentBeltGroup.RemoveLastBelt(removeResources: true, recalculateDistances: true);
		}
		else if (CurrentBeltGroup.IsLoop)
		{
			CurrentBeltGroup.IsLoop = false;
			CurrentBeltGroup.BreakLoop(this);
		}
		else
		{
			ConveyorBeltSystem.instance.SplitConveyorBeltGroup(CurrentBeltGroup, this);
		}
		if (updateNearbyConveyorsOnUnplace)
		{
			ConveyorBelt adjacentBuiltObject = LTFunctionLibrary.GetGrid().GetAdjacentBuiltObject<ConveyorBelt>(base.transform, OutputOrientation);
			if ((bool)adjacentBuiltObject)
			{
				adjacentBuiltObject.UpdateConveyorBeltType();
			}
		}
	}

	private void OnChangePosition(PlacementComponent component)
	{
		UpdateConveyorBeltType();
	}
}

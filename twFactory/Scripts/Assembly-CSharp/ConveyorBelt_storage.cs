using System;
using UnityEngine;

public class ConveyorBelt_storage : ConveyorBelt_straight, ISavable
{
	[SerializeField]
	private bool isInputStorage = true;

	[SerializeField]
	private Storage_ResourceData storage;

	[SerializeField]
	private bool usePlayerStorage;

	[SerializeField]
	private float positionOffset;

	private bool hasToIgnoreSave;

	public Storage_ResourceData Storage
	{
		get
		{
			if (usePlayerStorage)
			{
				return LTFunctionLibrary.GetPlayerInventory();
			}
			return storage;
		}
	}

	public override ConveyorBeltGroup CurrentBeltGroup
	{
		get
		{
			return base.CurrentBeltGroup;
		}
		set
		{
			if (CurrentBeltGroup != null)
			{
				CurrentBeltGroup.onStoreResource -= OnBeltGroupStoreResource;
			}
			base.CurrentBeltGroup = value;
			if (CurrentBeltGroup != null)
			{
				CurrentBeltGroup.onStoreResource += OnBeltGroupStoreResource;
			}
		}
	}

	public bool IsInputStorage => isInputStorage;

	public bool HasToIgnoreSave
	{
		get
		{
			return hasToIgnoreSave;
		}
		set
		{
			hasToIgnoreSave = value;
		}
	}

	public event Action<ResourceData, int> onStoreResource;

	private void OnValidate()
	{
		RecalculateOrientations();
	}

	private void RecalculateOrientations()
	{
		base.OutputOrientation = (IsInputStorage ? EOrientation.South : EOrientation.None);
		base.InputOrientation = (IsInputStorage ? EOrientation.None : EOrientation.South);
	}

	protected override void UpdateMovingDirection()
	{
		EOrientation localSpaceOrientation = (IsInputStorage ? base.OutputOrientation : base.InputOrientation);
		movingDirection = LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.OrientationToWorldSpace(localSpaceOrientation, base.transform));
		if (!IsInputStorage)
		{
			movingDirection *= -1f;
		}
	}

	public override Vector3 GetStartPosition()
	{
		if (IsInputStorage)
		{
			return base.transform.position + Vector3.up * base.Height + -LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.OrientationToWorldSpace(base.OutputOrientation, base.transform)) * (0.5f - positionOffset);
		}
		return base.transform.position + Vector3.up * base.Height + LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.OrientationToWorldSpace(base.InputOrientation, base.transform)) * 0.5f;
	}

	public override Vector3 GetEndPosition()
	{
		if (IsInputStorage)
		{
			return base.transform.position + Vector3.up * base.Height + LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.OrientationToWorldSpace(base.OutputOrientation, base.transform)) * 0.5f;
		}
		return base.transform.position + Vector3.up * base.Height + -LTFunctionLibrary.GetDirectionFromOrientation(LTFunctionLibrary.OrientationToWorldSpace(base.InputOrientation, base.transform)) * (0.5f - positionOffset);
	}

	public override float GetBeltDistance()
	{
		return Mathf.Max(1f - positionOffset, 0f);
	}

	protected override void UpdateConveyorBeltType()
	{
	}

	protected override bool ShowSpeed()
	{
		return false;
	}

	protected override bool ShowInputOrientation()
	{
		return false;
	}

	protected override bool ShowOutputOrientation()
	{
		return false;
	}

	protected override void OnPlace(PlacementComponent placementComponent)
	{
		RecalculateOrientations();
		base.OnPlace(placementComponent);
		if (IsInputStorage)
		{
			CurrentBeltGroup.InputStorage = Storage;
		}
		else
		{
			CurrentBeltGroup.OutputStorage = Storage;
		}
	}

	protected override void OnUnplace(PlacementComponent placementComponent)
	{
		if (IsInputStorage)
		{
			CurrentBeltGroup.InputStorage = null;
		}
		else
		{
			CurrentBeltGroup.OutputStorage = null;
		}
		Storage.SendAllResourcesToInventory();
		base.OnUnplace(placementComponent);
	}

	private void OnBeltGroupStoreResource(ResourceData resourceData, int amount)
	{
		this.onStoreResource?.Invoke(resourceData, amount);
	}

	public override void OnSave()
	{
		base.OnSave();
	}

	public bool IgnoreSave()
	{
		return HasToIgnoreSave;
	}
}

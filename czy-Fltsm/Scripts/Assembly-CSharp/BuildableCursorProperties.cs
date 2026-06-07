using System;
using PajamaLlama.Debugs;
using UnityEngine;

public abstract class BuildableCursorProperties : CursorProperties
{
	[Header("Buildable")]
	[SerializeField]
	protected VisualPrefabPreviewSettings _previewSettings;

	[NonSerialized]
	protected Buildable _buildable;

	[NonSerialized]
	protected int _visualIndex = -1;

	public virtual void Initialize(Buildable buildable, int visualIndex = -1)
	{
		_buildable = buildable;
		_visualIndex = buildable.ReturnVisualIndex(visualIndex);
	}

	public override void Activate()
	{
		if (_buildable == null)
		{
			Debugger.Error($"Tried activating construction cursor properties {base.name} while they were not initialized yet. Returning early...");
		}
		else if (GameManager.WorldManager != null)
		{
			GameManager.WorldManager.ShowConstructionBorder(enabled: true);
		}
	}

	public override void DeactivateImmediately()
	{
		if (GameManager.WorldManager != null)
		{
			GameManager.WorldManager.ShowConstructionBorder(enabled: false);
		}
		VisualBoundary.Display(display: false);
	}

	public virtual CountedItemProperty[] ReturnRequiredResources(BuildableProperties buildableProperties)
	{
		return buildableProperties.RequiredResources;
	}
}

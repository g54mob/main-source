using Aggro.Core;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class AnimateDecalMaterialFloatProperty : EntityBehaviourBase
{
	public string propertyName = "";

	public float value;

	private DecalProjector _decalProjector;

	private Material _newMaterial;

	private int _propertyID;

	protected override void OnEntityCreated()
	{
		_decalProjector = base.gameObject.GetComponent<DecalProjector>();
		_newMaterial = new Material(_decalProjector.material);
		_decalProjector.material = _newMaterial;
		_propertyID = Shader.PropertyToID(propertyName);
		_newMaterial.SetFloat(_propertyID, value);
	}

	protected override void OnEntityDestroyed()
	{
		Object.Destroy(_newMaterial);
	}

	protected override void OnUpdatePresentation()
	{
		if (Application.isEditor)
		{
			_propertyID = Shader.PropertyToID(propertyName);
		}
		_newMaterial.SetFloat(_propertyID, value);
	}
}

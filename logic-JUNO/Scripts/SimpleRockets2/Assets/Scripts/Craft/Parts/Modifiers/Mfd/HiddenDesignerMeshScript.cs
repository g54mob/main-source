using System;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Mfd
{
	public class HiddenDesignerMeshScript : MonoBehaviour
	{
		[SerializeField]
		private bool _designerOnly = true;

		[SerializeField]
		private bool _hideOnSelected = true;

		private PartScript _partScript;

		protected virtual void Awake()
		{
			if (Game.InFlightScene && _designerOnly)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
			}
			else
			{
				base.enabled = Game.InDesignerScene;
			}
		}

		protected virtual void OnDestroy()
		{
			if (_partScript?.PartMaterialScript != null)
			{
				_partScript.PartMaterialScript.StateChanged -= OnPartMaterialStateChanged;
			}
		}

		protected virtual void Start()
		{
			_partScript = GetComponentInParent<PartScript>();
			_partScript.PartMaterialScript.StateChanged += OnPartMaterialStateChanged;
			if (!_hideOnSelected)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private void OnPartMaterialStateChanged(object sender, EventArgs e)
		{
			PartScript partScript = _partScript;
			if (_hideOnSelected)
			{
				base.gameObject.SetActive(!partScript.PartMaterialScript.IsSelected && !partScript.PartMaterialScript.IsHighlighted);
			}
			else
			{
				base.gameObject.SetActive(partScript.PartMaterialScript.IsSelected || partScript.PartMaterialScript.IsHighlighted);
			}
		}
	}
}

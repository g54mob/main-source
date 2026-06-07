using System.Collections.Generic;
using System.Linq;
using ModApi;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Styles;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class PackageScript : PartModifierScript<PackageData>
	{
		private GameObject _package;

		private IPartStyle Style => base.PartScript.Data.Styles[0].Style;

		public override void OnModifiersCreated()
		{
			base.OnModifiersCreated();
		}

		public void UpdatePartStyle()
		{
			_ = Game.Instance.PartStyleManager;
			if (_package != null)
			{
				Object.DestroyImmediate(_package);
				_package = null;
			}
			string id = Style.Id;
			_package = Game.Instance.ResourceLoader.InstantiatePrefab("Craft/Parts/Prefabs/Packages/" + id);
			_package.transform.SetParent(base.gameObject.transform, worldPositionStays: false);
			Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(_package, base.gameObject.layer);
			_package.transform.localPosition = Vector3.zero;
			_package.transform.localScale = Vector3.one;
			_package.name = id;
			GameObject gameObject = Utilities.FindFirstGameObjectMyselfOrChildren("AttachPoints", _package);
			List<AttachPointScript> list = base.PartScript.AttachPointScripts.ToList();
			if (gameObject != null)
			{
				foreach (Transform transform in gameObject.transform)
				{
					AttachPointScript attachPointScript = list.Where((AttachPointScript x) => x.AttachPoint.Name == transform.name).FirstOrDefault();
					if (attachPointScript != null)
					{
						attachPointScript.AttachPoint.Enabled = true;
						attachPointScript.AttachPoint.Position = transform.localPosition;
						attachPointScript.AttachPoint.Rotation = transform.localRotation.eulerAngles;
						attachPointScript.transform.SetLocalPositionAndRotation(attachPointScript.AttachPoint.Position, Quaternion.Euler(attachPointScript.AttachPoint.Rotation));
						attachPointScript.gameObject.SetActive(value: true);
						list.Remove(attachPointScript);
					}
				}
			}
			Object.Destroy(gameObject);
			foreach (AttachPointScript item in list)
			{
				item.AttachPoint.Enabled = false;
			}
			base.PartScript.PartMaterialScript.UpdateRenderers();
			base.PartScript.InitializeColliders();
		}

		protected override void OnInitialized()
		{
			base.OnInitialized();
			UpdatePartStyle();
		}
	}
}

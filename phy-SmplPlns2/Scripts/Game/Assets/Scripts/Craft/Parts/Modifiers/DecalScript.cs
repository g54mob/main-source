using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.Craft.Decals;
using Assets.Scripts.Design;
using Assets.Scripts.Design.UI;
using DG.Tweening;
using Jundroo.Common.Utils;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class DecalScript : PartModifierScript, IPartTargetingHandler
	{
		private static Color32 _colorBoundsCube = new Color32(byte.MaxValue, 162, 78, byte.MaxValue);

		private static Color _colorProjectorCube = Constants.Colors.PrimaryLight;

		private WireframeCubeScript _boundsCube;

		private Transform _collider;

		private float _cubeScale = 1f;

		private DesignerUIScript _designerUI;

		private bool _hidden;

		private DecalPartIntersectionReceiver _intersectionReceiver;

		private WireframeCubeScript _projectorCube;

		private Transform _projectorTransform;

		private bool _selected;

		private Tweener _tween;

		public DecalData Data { get; private set; }

		private float CubeScale
		{
			get
			{
				return _cubeScale;
			}
			set
			{
				_cubeScale = value;
				_projectorCube.Scale = Vector3.one * value;
				_boundsCube.Scale = Vector3.one * value;
			}
		}

		public List<int> GetPartIDs()
		{
			if (_intersectionReceiver == null)
			{
				return new List<int>();
			}
			return _intersectionReceiver.Intersections.Select((PartScript x) => x.Part.Id).ToList();
		}

		public virtual void Initialize(DecalData data)
		{
			Data = data;
			_projectorTransform = Utilities.FindFirstGameObjectMyselfOrChildren("Projector", base.gameObject).transform;
			_collider = Utilities.FindFirstGameObjectMyselfOrChildren("Collider", base.gameObject).transform;
			_boundsCube = _projectorTransform.gameObject.AddComponent<WireframeCubeScript>();
			_boundsCube.LineWidth = 2.5f;
			_boundsCube.ToggleFaceVisibility(zPlus: true, zMinus: false, connectingEdges: true);
			_boundsCube.Color = _colorBoundsCube;
			_projectorCube = _projectorTransform.gameObject.AddComponent<WireframeCubeScript>();
			_projectorCube.LineWidth = 2.5f;
			_projectorCube.ToggleFaceVisibility(zPlus: false, zMinus: true, connectingEdges: false);
			_projectorCube.Color = _colorProjectorCube;
			base.PartScript.PartMaterialScript.SelectedChanged += OnSelectedChanged;
			base.PartScript.PartMaterialScript.HighlightedChanged += OnHighlightedChanged;
			_designerUI = Designer.Instance.DesignerScript.DesignerUI;
			_intersectionReceiver = new DecalPartIntersectionReceiver(null, Data, _projectorTransform);
		}

		public override void OnConnectedToPart(AttachPointData thisAttachPoint, PartData targetPart, AttachPointData targetAttachPoint, bool isSymmetryOperation)
		{
			base.OnConnectedToPart(thisAttachPoint, targetPart, targetAttachPoint, isSymmetryOperation);
			if (thisAttachPoint.Id == 1)
			{
				DecalData modifier = targetPart.GetModifier<DecalData>();
				if (modifier != null)
				{
					float y = targetAttachPoint.Position.y;
					Data.Depth = modifier.Depth + y;
					float num = modifier.Depth * modifier.Penetration + y;
					Data.Penetration = num / Data.Depth;
					Data.OnStacked();
				}
			}
		}

		public void OnDecalPropertiesUpdated()
		{
			UpdateScale();
		}

		public override void OnMirrored(PartData sourcePart)
		{
			base.OnMirrored(sourcePart);
			Data.DecalRotationZ = 0f - Data.DecalRotationZ;
		}

		public override void OnPartAdded()
		{
			base.OnPartAdded();
			_designerUI.DecalOutlinesVisible = true;
		}

		public void SetPartIDs(List<int> partIDs)
		{
			List<PartScript> list = new List<PartScript>();
			Assembly assembly = base.PartScript.Aircraft.Aircraft.Assembly;
			foreach (int partID in partIDs)
			{
				PartData partById = assembly.GetPartById(partID);
				if (partById != null)
				{
					list.Add(partById.PartScript);
				}
			}
			_intersectionReceiver.SetCustomParts(list);
		}

		protected void OnDestroy()
		{
			_intersectionReceiver?.Dispose();
			_intersectionReceiver = null;
			_tween?.Kill(complete: true);
			_tween = null;
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			base.RegisterUpdateMethods(in registrar);
			registrar.RegisterStart(OnStart, CraftUpdateFlags.DesignerDefault);
			registrar.RegisterUpdate(OnUpdate, CraftUpdateFlags.DesignerDefault);
		}

		private void OnHighlightedChanged(object sender, PartMaterialScript.PartMaterialEventArgs e)
		{
			UpdateCubeVisuals();
		}

		private void OnPartDeleted(object sender, PartScript.PartScriptEventArgs e)
		{
			_intersectionReceiver?.RemoveAllItems();
		}

		private void OnSelectedChanged(object sender, PartMaterialScript.PartMaterialEventArgs e)
		{
			UpdateCubeVisuals();
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			base.PartScript.PartDeleted += OnPartDeleted;
			_intersectionReceiver.SetManager(Designer.Instance.DesignerPartIntersectionManager);
			OnDecalPropertiesUpdated();
			UpdateCubeVisuals();
		}

		private void OnUpdate(in CraftUpdateFrameData frame)
		{
			if (_hidden != !_designerUI.DecalOutlinesVisible)
			{
				_hidden = !_designerUI.DecalOutlinesVisible;
				_collider.gameObject.SetActive(!_hidden);
				UpdateCubeVisuals();
			}
		}

		private void UpdateCubeVisuals()
		{
			bool isSelected = base.PartScript.PartMaterialScript.IsSelected;
			bool isHighlighted = base.PartScript.PartMaterialScript.IsHighlighted;
			_tween?.Kill(complete: true);
			_tween = null;
			_projectorCube.IsVisible = !_hidden;
			_boundsCube.IsVisible = (isSelected || isHighlighted) && _projectorCube.IsVisible;
			if (isSelected)
			{
				_projectorCube.LineWidth = (isHighlighted ? 5f : 4f);
				_projectorCube.Opacity = 1f;
				_boundsCube.Opacity = 1f;
				_boundsCube.Color = _colorBoundsCube;
				if (!_selected)
				{
					CubeScale = 1.125f;
					_tween = DOTween.To(() => CubeScale, delegate(float x)
					{
						CubeScale = x;
					}, 1f, 0.15f).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true);
				}
			}
			else if (isHighlighted)
			{
				_projectorCube.LineWidth = 3f;
				_projectorCube.Opacity = 1f;
				_boundsCube.Opacity = 0.75f;
				_boundsCube.Color = Color.white;
				CubeScale = 1f;
				_tween = DOTween.To(() => CubeScale, delegate(float x)
				{
					CubeScale = x;
				}, 1.05f, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo)
					.SetUpdate(isIndependentUpdate: true);
			}
			else
			{
				_projectorCube.LineWidth = 3f;
				_projectorCube.Opacity = 0.75f;
				_tween = DOTween.To(() => CubeScale, delegate(float x)
				{
					CubeScale = x;
				}, 1f, 0.125f).SetEase(Ease.OutBack).SetUpdate(isIndependentUpdate: true);
			}
			_boundsCube.LineWidth = _projectorCube.LineWidth;
			_selected = isSelected;
		}

		private void UpdateScale()
		{
			float num = Data.Depth * Mathf.Clamp01(Data.Penetration);
			_projectorTransform.parent.localPosition = new Vector3(0f, Data.Depth - num, 0f);
			_projectorTransform.localRotation = Quaternion.Euler(Data.DecalRotation);
			_collider.localScale = new Vector3(Data.Size.x, Mathf.Min(Data.Size.x, Data.Height), Data.Size.y);
			Vector3 point = Vector3.Scale(Data.Size, new Vector3(-0.5f, -0.5f, 0f));
			Vector3 point2 = Vector3.Scale(Data.Size, new Vector3(0.5f, 0.5f, 1f));
			_projectorCube.SetCornerPoints(point, point2);
			_boundsCube.SetCornerPoints(point, point2);
		}
	}
}

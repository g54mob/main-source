using System;
using CTS.BBT.AI;
using CTS.Core;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	[DefaultExecutionOrder(2)]
	public class MeshChanger : CTSBehaviour
	{
		[SerializeField]
		private Transform _headSlot;

		[SerializeField]
		private AgentEyesBlinkControler _agentEyesBlinkControler;

		[InjectScope(EGetScope.Parent)]
		[Inject(false)]
		private Agent _agent;

		[Inject(false)]
		private AgentVisual _visualData;

		[Inject(false)]
		private Animator _animator;

		[Inject(false)]
		private BarVisualObject _barVisualObject;

		[InjectScope(EGetScope.Children)]
		[Inject(false)]
		private SkinnedMeshRenderer _skinnedMeshRenderer;

		private Renderer[] _headRenderers;

		[SerializeField]
		[BoxGroup("Testing")]
		private EGender _gender;

		[SerializeField]
		[BoxGroup("Testing")]
		private ESpecies _species;

		[SerializeField]
		[BoxGroup("Testing")]
		private EEthnics _ethnics;

		[SerializeField]
		[BoxGroup("Testing")]
		private ESubSpecies _subspecies;

		public Avatar SelectedAvatar { get; private set; }

		public Mesh SelectedBodyMesh { get; private set; }

		public Material[] SelectedMaterials { get; private set; }

		[field: SerializeField]
		public CharacterHeadVisual CharacterHeadVisual { get; private set; }

		[field: SerializeField]
		public CharacterBodyVisual CharacterBodyVisual { get; private set; }

		public GameObject SelectedHeadGO => CharacterHeadVisual.gameObject;

		protected override void OnAwake()
		{
			base.OnAwake();
			_agent.Selection.OutlineRenderers.AddRenderer(_skinnedMeshRenderer);
		}

		public void GenerateHeadNBody(ref CharacterData generateData)
		{
			CreateHead(ref generateData);
			CreateBody(ref generateData);
			_visualData.ClearRenderers();
			_barVisualObject.RefreshComponents();
			_headRenderers = SelectedHeadGO.GetComponentsInChildren<Renderer>();
			_agent.Selection.OutlineRenderers.AddRenderers(_headRenderers);
			_visualData.AddRenderers(_headRenderers);
			_visualData.EyesMaterial = _headRenderers[0].materials[1];
			SelectedAvatar = CharacterVisualManager.GetAvatar(generateData.Gender, generateData.Species, generateData.Ethnics, generateData.SubSpecies).avatar;
			_animator.avatar = SelectedAvatar;
			Renderer[] renderers = new Renderer[1] { _skinnedMeshRenderer };
			_agent.Selection.OutlineRenderers.AddRenderer(_skinnedMeshRenderer);
			_visualData.AddRenderers(renderers);
			_agentEyesBlinkControler.SetSkinnedMeshRenderer = SelectedHeadGO.GetComponentInChildren<SkinnedMeshRenderer>();
		}

		private void CreateHead(ref CharacterData data)
		{
			MeshAndMaterial? hair = CharacterVisualManager.GetHair(data);
			IndexedMaterial? eyeSkin = CharacterVisualManager.GetEyeSkin(data);
			IndexedMaterial? headSkin = CharacterVisualManager.GetHeadSkin(data);
			IndexedCharacterBlenshapeData? blendShape = CharacterVisualManager.GetBlendShape(data);
			if (!hair.HasValue || !eyeSkin.HasValue || !headSkin.HasValue || !blendShape.HasValue)
			{
				Debug.LogException(new Exception("Failed to create head"));
				return;
			}
			CharacterHeadVisual.SetHair(hair.Value);
			CharacterHeadVisual.SetEyesMaterial(eyeSkin.Value.material);
			CharacterHeadVisual.SetSkinMaterial(headSkin.Value.material);
			CharacterHeadVisual.SetBlendshape(blendShape.Value.so.meshBlendShape);
			data.hairMatIndex = hair.Value.matIndex;
			data.hairMeshIndex = hair.Value.meshIndex;
			data.eyesMaterialIndex = eyeSkin.Value.index;
			data.headSkinMaterialIndex = headSkin.Value.index;
			data.headBlendIndex = blendShape.Value.index;
		}

		private void CreateBody(ref CharacterData data)
		{
			SetBody(ref data);
			IndexedMaterial? bodySkin = CharacterVisualManager.GetBodySkin(data);
			if (!bodySkin.HasValue)
			{
				Debug.LogException(new Exception("Failed to create body"));
				return;
			}
			data.bodySkinMaterialIndex = bodySkin.Value.index;
			CharacterBodyVisual.SetSkinMaterial(bodySkin.Value.material);
			SelectedMaterials = CharacterBodyVisual.GetCurrentMaterials;
		}

		public void SetBody(ref CharacterData data)
		{
			BodySet? body = CharacterVisualManager.GetBody(data);
			if (body.HasValue)
			{
				data.bodyDataIndex = body.Value.meshIndex;
				data.bodyMaterialGroupIndex = body.Value.materialIndex;
				CharacterBodyVisual.SetBodySet(body.Value);
				SelectedBodyMesh = CharacterBodyVisual.GetCurrentMesh;
				SelectedMaterials = CharacterBodyVisual.GetCurrentMaterials;
			}
		}

		public void ClearRenderers()
		{
			if (_skinnedMeshRenderer != null)
			{
				_agent.Selection.OutlineRenderers.RemoveRenderer(_skinnedMeshRenderer);
			}
			if (_headRenderers != null)
			{
				_agent.Selection.OutlineRenderers.RemoveRenderers(_headRenderers);
			}
		}
	}
}

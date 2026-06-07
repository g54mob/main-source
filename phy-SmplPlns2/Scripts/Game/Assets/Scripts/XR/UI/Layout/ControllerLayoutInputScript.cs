using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.XR.UI.Layout
{
	public class ControllerLayoutInputScript : MonoBehaviour
	{
		[Serializable]
		private class InputMesh
		{
			[field: SerializeField]
			public MeshFilter MeshFilter { get; private set; }

			public MeshRenderer MeshRenderer { get; private set; }

			[field: SerializeField]
			public int SubmeshIndex { get; private set; }

			public void Initialize()
			{
				MeshRenderer = MeshFilter.GetComponent<MeshRenderer>();
			}
		}

		private readonly Color _blinkColor = new Color(0f, 1f, 0f, 1f);

		private readonly float _blinkPeriod = 1f;

		private bool _boldColor;

		private MaterialPropertyBlock _highlightMaterialPropertyBlock;

		[SerializeField]
		private InputID[] _inputIds;

		private TextMeshPro _label;

		[SerializeField]
		private List<InputMesh> _meshes;

		public bool BoldColor
		{
			get
			{
				return _boldColor;
			}
			set
			{
				_boldColor = value;
				_label.color = (_boldColor ? new Color32(byte.MaxValue, 138, 0, byte.MaxValue) : new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue));
			}
		}

		public List<string> InputPaths
		{
			get
			{
				List<string> list = new List<string>();
				InputID[] inputIds = _inputIds;
				foreach (InputID inputID in inputIds)
				{
					list.Add(GetInputPath(inputID));
				}
				return list;
			}
		}

		public bool IsHighlighted { get; set; }

		public string Text
		{
			get
			{
				return _label.text;
			}
			set
			{
				_label.text = value;
			}
		}

		public bool Visible
		{
			get
			{
				return base.gameObject.activeSelf;
			}
			set
			{
				base.gameObject.SetActive(value);
			}
		}

		public string GetInputPath(InputID inputID)
		{
			return inputID switch
			{
				InputID.Grip => "grip", 
				InputID.GripPressed => "gripPressed", 
				InputID.JoystickClicked => "joystickClicked", 
				InputID.Menu => "menu", 
				InputID.Primary2DAxisX => "primary2DAxis/X", 
				InputID.Primary2DAxisY => "primary2DAxis/Y", 
				InputID.PrimaryButton => "primaryButton", 
				InputID.SecondaryButton => "secondaryButton", 
				InputID.Trigger => "trigger", 
				InputID.TriggerPressed => "triggerPressed", 
				InputID.TrackpadClicked => "trackpadClicked", 
				_ => throw new NotImplementedException($"Input ID has no corresponding path: {inputID}"), 
			};
		}

		protected virtual void Awake()
		{
			_label = GetComponentInChildren<TextMeshPro>();
			foreach (InputMesh mesh in _meshes)
			{
				mesh.Initialize();
			}
		}

		protected virtual void LateUpdate()
		{
			if (!IsHighlighted)
			{
				return;
			}
			MaterialPropertyBlock materialPropertyBlock = _highlightMaterialPropertyBlock ?? (_highlightMaterialPropertyBlock = new MaterialPropertyBlock());
			float num = _blinkPeriod * 0.5f;
			float num2 = Time.realtimeSinceStartup % _blinkPeriod / num;
			if (num2 > 1f)
			{
				num2 = 2f - num2;
			}
			num2 *= num2;
			foreach (InputMesh mesh in _meshes)
			{
				Color value = Color.Lerp(mesh.MeshRenderer.sharedMaterials[mesh.SubmeshIndex].color, _blinkColor, num2);
				materialPropertyBlock.SetColor("_Color", value);
				mesh.MeshRenderer.SetPropertyBlock(materialPropertyBlock, mesh.SubmeshIndex);
			}
		}

		protected virtual void Update()
		{
			if (_highlightMaterialPropertyBlock == null)
			{
				return;
			}
			_highlightMaterialPropertyBlock.Clear();
			foreach (InputMesh mesh in _meshes)
			{
				mesh.MeshRenderer.SetPropertyBlock(_highlightMaterialPropertyBlock, mesh.SubmeshIndex);
			}
		}
	}
}

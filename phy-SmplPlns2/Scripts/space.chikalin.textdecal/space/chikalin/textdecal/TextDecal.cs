using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace space.chikalin.textdecal
{
	[ExecuteAlways]
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-80)]
	[AddComponentMenu("Rendering/Text Decal")]
	[HelpURL("https://assetstore.unity.com/packages/vfx/shaders/text-decal-302653")]
	[RequireComponent(typeof(TMP_Text))]
	public class TextDecal : MonoBehaviour
	{
		[Serializable]
		public class TextDecalSettings
		{
			[Tooltip("Volumetric mesh depth")]
			public float projectionDepth = 1f;

			public static UVChannel vertexDataDefault = UVChannel.TEXCOORD5;

			public static UVChannel UVDataDefault = UVChannel.TEXCOORD6;

			public static UVChannel rotationDataDefault = UVChannel.TEXCOORD7;

			public bool useDefaultUV = true;

			[Tooltip("Default value is TEXCOORD5")]
			public UVChannel vertexData;

			[Tooltip("Default value is TEXCOORD6")]
			public UVChannel UVData;

			[Tooltip("Default value is TEXCOORD7")]
			public UVChannel rotationData;
		}

		[SerializeField]
		public TextDecalSettings settings;

		private TMP_Text _text;

		private readonly Dictionary<int, TextDecalMeshInfo> _decalMeshInfo = new Dictionary<int, TextDecalMeshInfo>();

		private readonly Dictionary<Mesh, MeshFilter> _subTextMeshes = new Dictionary<Mesh, MeshFilter>();

		private void Awake()
		{
			_text = GetComponent<TMP_Text>();
			if (settings == null)
			{
				settings = new TextDecalSettings();
			}
		}

		private void OnEnable()
		{
			_text.OnPreRenderText += OnPreRenderText;
			TMPro_EventManager.TEXT_CHANGED_EVENT.Add(OnTextChangedEvent);
			OnPreRenderText(_text.textInfo);
		}

		private void OnDisable()
		{
			TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(OnTextChangedEvent);
			_text.OnPreRenderText -= OnPreRenderText;
			_text.ForceMeshUpdate();
			TMP_MeshInfo[] meshInfo = _text.textInfo.meshInfo;
			for (int i = 0; i < meshInfo.Length; i++)
			{
				if (_decalMeshInfo.ContainsKey(i))
				{
					TMP_MeshInfo tMP_MeshInfo = meshInfo[i];
					TextDecalMeshInfo textDecalMeshInfo = _decalMeshInfo[i];
					textDecalMeshInfo.Mesh = tMP_MeshInfo.mesh;
					if (textDecalMeshInfo.VolumetricMesh != null)
					{
						UnityEngine.Object.DestroyImmediate(textDecalMeshInfo.VolumetricMesh);
					}
					textDecalMeshInfo.Dispose();
				}
			}
		}

		private void OnTextChangedEvent(UnityEngine.Object obj)
		{
			if (!(obj != (UnityEngine.Object)(object)_text) && string.IsNullOrEmpty(_text.text))
			{
				OnPreRenderText(_text.textInfo);
			}
		}

		private void OnPreRenderText(TMP_TextInfo textInfo)
		{
			if (textInfo == null)
			{
				Debug.LogError("TMP_TextInfo is null. Please <b>import the TMP Essential Resources</b>.");
				return;
			}
			PrepareMeshData(textInfo);
			for (int i = 0; i < textInfo.characterCount; i++)
			{
				TMP_CharacterInfo charInfo = textInfo.characterInfo[i];
				if (charInfo.isVisible)
				{
					int materialReferenceIndex = charInfo.materialReferenceIndex;
					TMP_MeshInfo meshInfo = textInfo.meshInfo[materialReferenceIndex];
					if (_decalMeshInfo.ContainsKey(materialReferenceIndex))
					{
						_decalMeshInfo[materialReferenceIndex].AddCharacter(charInfo, meshInfo, settings);
					}
				}
			}
			foreach (TextDecalMeshInfo value in _decalMeshInfo.Values)
			{
				value.UpdateMesh(settings);
			}
		}

		private void PrepareMeshData(TMP_TextInfo textInfo)
		{
			_subTextMeshes.Clear();
			TMP_SubMesh[] componentsInChildren = GetComponentsInChildren<TMP_SubMesh>();
			foreach (TMP_SubMesh tMP_SubMesh in componentsInChildren)
			{
				_subTextMeshes.Add(tMP_SubMesh.mesh, tMP_SubMesh.meshFilter);
			}
			_subTextMeshes.Add(textInfo.meshInfo[0].mesh, GetComponent<MeshFilter>());
			for (int j = 0; j < textInfo.meshInfo.Length; j++)
			{
				TMP_MeshInfo tMP_MeshInfo = textInfo.meshInfo[j];
				if (_subTextMeshes.ContainsKey(tMP_MeshInfo.mesh))
				{
					if (!_decalMeshInfo.ContainsKey(j))
					{
						_decalMeshInfo.Add(j, new TextDecalMeshInfo());
					}
					_decalMeshInfo[j].PrepareMeshData(tMP_MeshInfo.vertexCount, _subTextMeshes[tMP_MeshInfo.mesh]);
				}
			}
		}

		public void ForceDecalUpdate()
		{
			OnPreRenderText(_text.textInfo);
		}
	}
}

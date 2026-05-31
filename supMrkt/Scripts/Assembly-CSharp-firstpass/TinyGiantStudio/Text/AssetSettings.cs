using UnityEngine;
using UnityEngine.InputSystem;

namespace TinyGiantStudio.Text
{
	public class AssetSettings : ScriptableObject
	{
		public enum MeshExportStyle
		{
			exportAsObj = 0,
			exportAsMeshAsset = 1
		}

		public enum CharInputStyle
		{
			CharacterRange = 0,
			UnicodeRange = 1,
			CustomCharacters = 2,
			UnicodeSequence = 3
		}

		[HideInInspector]
		public string selectedTab;

		public Color tabSelectedColor;

		public Color tabUnselectedColor;

		[Space]
		public Color gridItemColor;

		public Color importantLabelColor_darkSkin;

		public Color importantLabelColor_lightSkin;

		public Color openedFoldoutTitleColor_darkSkin;

		public Color openedFoldoutTitleColor_lightSkin;

		public Font defaultFont;

		public Vector3 defaultTextSize;

		public Material defaultTextMaterial;

		public Vector3 defaultButtonNormalTextSize;

		public Material defaultButtonNormalTextMaterial;

		public Material defaultButtonNormalBackgroundMaterial;

		public Vector3 defaultButtonSelectedTextSize;

		public Material defaultButtonSelectedTextMaterial;

		public Material defaultButtonSelectedBackgroundMaterial;

		public Vector3 defaultButtonPressedTextSize;

		public Material defaultButtonPressedTextMaterial;

		public Material defaultButtonPressedBackgroundMaterial;

		public Vector3 defaultButtonDisabledTextSize;

		public Material defaultButtonDisabledTextMaterial;

		public Material defaultButtonDisabledBackgroundMaterial;

		public Vector3 defaultListNormalTextSize;

		public Material defaultListNormalTextMaterial;

		public Material defaultListNormalBackgroundMaterial;

		public Vector3 defaultListSelectedTextSize;

		public Material defaultListSelectedTextMaterial;

		public Material defaultListSelectedBackgroundMaterial;

		public Vector3 defaultListPressedTextSize;

		public Material defaultListPressedTextMaterial;

		public Material defaultListPressedBackgroundMaterial;

		public Vector3 defaultListDisabledTextSize;

		public Material defaultListDisabledTextMaterial;

		public Material defaultListDisabledBackgroundMaterial;

		[Header("Inspector field size")]
		public float smallHorizontalFieldSize;

		public float normalHorizontalFieldSize;

		public float largeHorizontalFieldSize;

		public float extraLargeHorizontalFieldSize;

		public bool autoCreateSceneInputSystem;

		public bool dontAutoCreateRaycasterOrButtonIfVRtoolkitExists;

		public CharInputStyle charInputStyle;

		public char startChar;

		public char endChar;

		public string startUnicode;

		[HideInInspector]
		public string endUnicode;

		[HideInInspector]
		[TextArea(10, 99)]
		public string customCharacters;

		[HideInInspector]
		[TextArea(10, 99)]
		public string unicodeSequence;

		[HideInInspector]
		public int vertexDensity;

		[HideInInspector]
		public float sizeXY;

		[HideInInspector]
		public float sizeZ;

		[HideInInspector]
		public int smoothingAngle;

		[HideInInspector]
		public MeshExportStyle meshExportStyle;

		[HideInInspector]
		public int previewAmount;

		[SerializeField]
		private InputActionAsset _inputActionAsset;

		public InputActionAsset InputActionAsset
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public void FindModularTextInputActionAsset()
		{
		}

		public void ResetFontCreationMeshSettings()
		{
		}

		public void ResetFontCreationPrebuiltSettings()
		{
		}
	}
}

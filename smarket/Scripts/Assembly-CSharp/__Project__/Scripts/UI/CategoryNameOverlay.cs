using TMPro;
using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.ControllerInputModule;

namespace __Project__.Scripts.UI
{
	public class CategoryNameOverlay : NoktaSingleton<CategoryNameOverlay>
	{
		[SerializeField]
		private TMP_InputField m_NameInput;

		[SerializeField]
		private Button m_ChangeNameButton;

		[SerializeField]
		private Button m_CancelButton;

		[SerializeField]
		private GameObject m_InteractableParent;

		[SerializeField]
		private GameObject m_EnterNameText;

		[SerializeField]
		private TMP_Text m_ApprovedCanvas;

		[SerializeField]
		private CategorySignColorDropdown m_TextColorDropdown;

		[SerializeField]
		private CategorySignColorDropdown m_BackgroundColorDropdown;

		[SerializeField]
		private CategorySignIconController m_IconController;

		private string m_CachedName;

		private int m_cachedTextMaterialIndex;

		private int m_cachedBackgroundMaterialIndex;

		private Vector2Int m_cachedIconIndex;

		public CategorySign currentCategorySign;

		public GamePadUIPanel gamePadUIPanel;

		[HideInInspector]
		public int selectedColorIndex;

		[HideInInspector]
		public int selectedBackGroundColorIndex;

		[HideInInspector]
		public Vector2Int selectedIconIndex;

		public bool IsAnythingChanged => false;

		public void Initialize()
		{
		}

		private void SetSignName(string signName)
		{
		}

		public void ApproveSignName()
		{
		}

		public void Cancel()
		{
		}

		public void OnTextColorChanged(int value)
		{
		}

		public void OnBackgroundColorChanged(int value)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}
	}
}

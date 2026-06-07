using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Gh.Tk.UI
{
	public class BindingVisual : MonoBehaviour
	{
		public string defaultActionPath;

		public int defaultBindingIndex;

		public string layerOverride;

		public bool useDissolveMaterials;

		[SerializeField]
		private Container3DUIView _container;

		[SerializeField]
		private GameObject _mouseParent;

		[SerializeField]
		private GameObject _mouseLeftClick;

		[SerializeField]
		private GameObject _mouseRightClick;

		[SerializeField]
		private GameObject _mouseMiddleClick;

		[SerializeField]
		private GameObject _mouse4;

		[SerializeField]
		private GameObject _mouse5;

		[SerializeField]
		private GameObject _mouse6;

		[SerializeField]
		private GameObject _mouse7;

		[SerializeField]
		private GameObject _mouseMove;

		[SerializeField]
		private GameObject _mouseArrowVertical;

		[SerializeField]
		private GameObject _mouseArrowHorizontal;

		[SerializeField]
		private GameObject _infoParent;

		[SerializeField]
		private TMP_Text _infoText;

		public BoxCollider groupCollider;

		public bool centerGroupCollider;

		public const string NamedKeyPathPrefix = "NK-";

		private List<string> _longKeyPaths;

		[SerializeField]
		private BoxCollider _standardMouseCollider;

		[SerializeField]
		private BoxCollider _wideMouseCollider;

		[SerializeField]
		private GameObject _longKeyPrefab;

		private List<GameObject> _longKeys;

		[SerializeField]
		private GameObject _characterKeyPrefab;

		private List<GameObject> _characterKeys;

		protected void OnEnable()
		{
		}

		public void ResizeCollider()
		{
		}

		public static List<InputBinding> GetBindings(string actionBindingPath, int bindingIndex)
		{
			return null;
		}

		public void SetNamedKeyPath(string path, int bindingIndex)
		{
		}

		public void SetBinding(string actionBindingPath, int bindingIndex)
		{
		}

		public void SetBinding(List<InputBinding> bindings)
		{
		}

		private void SetInputVisual(InputBinding binding, int positionIndex)
		{
		}

		private string GetDisplayName(InputBinding binding)
		{
			return null;
		}

		private void SetInfo(string info, int positionIndex)
		{
		}

		private void SetMouse(string button, int positionIndex, bool isMousePart = false, string actionName = null)
		{
		}

		private void ResetMouse()
		{
		}

		private void SetArrowKey(string id, GameObject key)
		{
		}

		private void SetKey(string textKey, GameObject key)
		{
		}

		private GameObject GetLongKey(int positionIndex)
		{
			return null;
		}

		private GameObject GetCharacterKey(int positionIndex)
		{
			return null;
		}

		public void ClearVisual()
		{
		}
	}
}

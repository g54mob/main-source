using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class TextSizeGroup : MonoBehaviour
	{
		[Header("Needs to implement IAutoFontSizeElement and ITextChanged")]
		public ObservableCollection<MonoBehaviour> Texts;

		[SerializeField]
		[FormerlySerializedAs("Texts")]
		private List<MonoBehaviour> _texts;

		private List<TMP_InputField> _inputFields;

		public bool ShouldAutoSearchForTexts;

		public float maxFontSize;

		public float minFontSize;

		public bool ignoreStdDeviation;

		public static TextSizeGroup AddGroup(GameObject go, int maxSize)
		{
			return null;
		}

		private void Start()
		{
		}

		private void FetchCorrespondingInputFields(IList texts)
		{
		}

		private void OnInputChanged(string text)
		{
		}

		private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
		}

		private void OnTextChanged(object sender, EventArgs e)
		{
		}

		public void MarkAsDirty()
		{
		}

		private void LateUpdate()
		{
		}

		private void UpdateTextSizes()
		{
		}

		private void RemoveInvalidObjects()
		{
		}

		private float GetOptimalSizeWithoutScale(IAutoFontSizeElement text)
		{
			return 0f;
		}

		public void ClearTexts()
		{
		}
	}
}

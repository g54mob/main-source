using System;
using UnityEngine;

namespace ModApi.Ui
{
	public interface IXmlLayout
	{
		GameObject GameObject { get; }

		IXmlLayout ParentLayout { get; }

		string Xml { get; set; }

		IXmlLayoutController XmlLayoutController { get; }

		T GetElementById<T>(string id);

		IXmlElement GetElementById(string id);

		string GetElementId(RectTransform element);

		void Hide(Action onCompleteCallback = null, bool forceEvenIfNotVisible = false);

		void RebuildLayout(bool forceEvenIfXmlUnchanged = false, bool throwExceptionIfXmlIsInvalid = false);

		void Show(Action onCompleteCallback = null, bool forceEvenIfVisible = false);
	}
}

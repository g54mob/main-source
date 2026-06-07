using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DV.CabControls
{
	[DisallowMultipleComponent]
	public class ControlDebug : MonoBehaviour
	{
		private List<string> lines = new List<string>(10);

		private TextMesh txt;

		private Coroutine clearCoro;

		private void Start()
		{
			GameObject gameObject = new GameObject(base.gameObject.name + " [debug text]");
			gameObject.transform.parent = base.transform.parent;
			gameObject.transform.position = base.transform.position + Vector3.up * 0.2f;
			gameObject.transform.localScale = Vector3.one * 0.01f;
			txt = gameObject.AddComponent<TextMesh>();
			ControlImplBase component = GetComponent<ControlImplBase>();
			component.Used += delegate
			{
				AddText("Used");
			};
			component.Grabbed += delegate
			{
				AddText("Grabbed");
			};
			component.Ungrabbed += delegate
			{
				AddText("Ungrabbed");
			};
			component.ValueChanged += delegate(ValueChangedEventArgs e)
			{
				AddText($"Value changed: {e.newValue:0.##}");
			};
		}

		private void AddText(string msg)
		{
			if (lines.Count == lines.Capacity)
			{
				lines.RemoveAt(lines.Count - 1);
			}
			lines.Insert(0, msg);
			txt.text = string.Join("\n", lines);
			if (clearCoro != null)
			{
				StopCoroutine(clearCoro);
			}
			clearCoro = StartCoroutine(ClearCoro());
		}

		private IEnumerator ClearCoro()
		{
			yield return WaitFor.Seconds(3f);
			while (lines.Count != 0)
			{
				lines.RemoveAt(lines.Count - 1);
				txt.text = string.Join("\n", lines);
				yield return WaitFor.Seconds(0.1f);
			}
			clearCoro = null;
		}
	}
}

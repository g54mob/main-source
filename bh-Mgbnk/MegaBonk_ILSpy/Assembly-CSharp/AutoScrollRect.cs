using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AutoScrollRect : MonoBehaviour
{
	public ScrollRect scrollRect;

	public RectTransform viewport;

	public RectTransform content;

	public GameObject lastSelected;

	private void Update()
	{
		EventSystem current = EventSystem.current;
		if (!(current != null))
		{
			return;
		}
		EventSystem current2 = EventSystem.current;
		if (!(current2.m_CurrentSelected != null))
		{
			return;
		}
		EventSystem current3 = EventSystem.current;
		if (current3.m_CurrentSelected != null)
		{
			Transform transform = current3.m_CurrentSelected.transform;
			if (transform.IsChildOf(content) && current3.m_CurrentSelected != lastSelected)
			{
				RectTransform component = current3.m_CurrentSelected.GetComponent<RectTransform>();
				EnsureVisible(component);
				lastSelected = current3.m_CurrentSelected;
			}
		}
	}

	private unsafe void EnsureVisible(RectTransform target, float padding = 20f)
	{
		//IL_006c: Expected O, but got Ref
		//IL_0085: Expected O, but got Ref
		//IL_009e: Expected O, but got Ref
		//IL_00b6: Expected O, but got Ref
		Canvas.ForceUpdateCanvases();
		LayoutRebuilder.ForceRebuildLayoutImmediate(content);
		Vector3[] fourCornersArray = new Vector3[4];
		Vector3[] fourCornersArray2 = new Vector3[4];
		viewport.GetWorldCorners(fourCornersArray);
		target.GetWorldCorners(fourCornersArray2);
		Vector3 vector2 = default(Vector3);
		Vector3 vector = viewport.InverseTransformPoint((Vector3)(&vector2));
		Vector3 vector3 = viewport.InverseTransformPoint((Vector3)(&vector2));
		Vector3 vector4 = viewport.InverseTransformPoint((Vector3)(&vector2));
		Vector3 vector5 = viewport.InverseTransformPoint((Vector3)(&vector2));
		float num = vector.y - padding;
		if (!(vector4.y > num))
		{
			float num2 = vector3.y + padding;
			if (!(num2 > vector5.y))
			{
			}
		}
		Vector2 anchoredPosition = content.anchoredPosition;
		Vector2 anchoredPosition2 = default(Vector2);
		content.anchoredPosition = anchoredPosition2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180578BE0");
	}

	public void ManualRefresh()
	{
		if (lastSelected != null)
		{
			RectTransform component = lastSelected.GetComponent<RectTransform>();
			EnsureVisible(component);
		}
	}
}

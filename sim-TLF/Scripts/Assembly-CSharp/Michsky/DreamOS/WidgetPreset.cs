using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Michsky.DreamOS
{
	[RequireComponent(typeof(Animator))]
	public class WidgetPreset : MonoBehaviour, IEndDragHandler, IEventSystemHandler
	{
		public Animator widgetAnimator;

		private float widgetPosX;

		private float widgetPosY;

		private float cachedAnimatorLength = 0.5f;

		private bool isInitialized;

		[HideInInspector]
		public WidgetManager.DefaultWidgetState defaultState;

		[HideInInspector]
		public WidgetManager manager;

		[HideInInspector]
		public int index;

		[HideInInspector]
		public string ID;

		private DreamOSDataManager.DataCategory dataCat = DreamOSDataManager.DataCategory.Widgets;

		private void Awake()
		{
			if (widgetAnimator != null)
			{
				cachedAnimatorLength = DreamOSInternalTools.GetAnimatorClipLength(widgetAnimator, "WidgetPreset_In") + 0.1f;
			}
		}

		private void OnEnable()
		{
			if (!isInitialized)
			{
				base.enabled = false;
				isInitialized = true;
			}
			else if (DreamOSDataManager.ContainsJsonKey(dataCat, ID + "_Enabled") && DreamOSDataManager.ReadBooleanData(dataCat, ID + "_Enabled"))
			{
				SetEnabled(updateData: false);
			}
			else if (DreamOSDataManager.ContainsJsonKey(dataCat, ID + "_Enabled") && !DreamOSDataManager.ReadBooleanData(dataCat, ID + "_Enabled"))
			{
				SetDisabled(updateData: false);
			}
			else if (defaultState == WidgetManager.DefaultWidgetState.Disabled)
			{
				SetDisabled();
			}
			else if (defaultState == WidgetManager.DefaultWidgetState.Enabled)
			{
				SetEnabled();
			}
		}

		public void SetEnabled(bool updateData = true)
		{
			if (updateData)
			{
				DreamOSDataManager.WriteBooleanData(dataCat, ID + "_Enabled", value: true);
			}
			manager.widgetItems[index].libraryItem.itemSwitch.SetOn(notifyEvents: false);
			if (DreamOSDataManager.ContainsJsonKey(dataCat, ID + "_PosX"))
			{
				widgetPosX = DreamOSDataManager.ReadFloatData(dataCat, ID + "_PosX");
				widgetPosY = DreamOSDataManager.ReadFloatData(dataCat, ID + "_PosY");
				base.gameObject.transform.localPosition = new Vector3(widgetPosX, widgetPosY, 0f);
			}
			base.gameObject.SetActive(value: true);
			widgetAnimator.enabled = true;
			widgetAnimator.Play("In");
			StopCoroutine("DisableAnimator");
			StopCoroutine("DisableObject");
			StartCoroutine("DisableAnimator");
		}

		public void SetDisabled(bool updateData = true)
		{
			if (updateData)
			{
				DreamOSDataManager.WriteBooleanData(dataCat, ID + "_Enabled", value: false);
			}
			manager.widgetItems[index].libraryItem.itemSwitch.SetOff(notifyEvents: false);
			if (widgetAnimator.gameObject.activeInHierarchy)
			{
				widgetAnimator.enabled = true;
				widgetAnimator.Play("Out");
				StopCoroutine("DisableAnimator");
				StopCoroutine("DisableObject");
				StartCoroutine("DisableObject");
			}
		}

		public void AlignToCenter()
		{
			base.gameObject.transform.localPosition = new Vector3(0f, 0f, 0f);
			widgetPosX = base.gameObject.transform.localPosition.x;
			widgetPosY = base.gameObject.transform.localPosition.y;
			DreamOSDataManager.WriteFloatData(dataCat, ID + "_PosX", widgetPosX);
			DreamOSDataManager.WriteFloatData(dataCat, ID + "_PosY", widgetPosY);
		}

		public void OnEndDrag(PointerEventData data)
		{
			widgetPosX = base.gameObject.transform.localPosition.x;
			widgetPosY = base.gameObject.transform.localPosition.y;
			base.gameObject.transform.localPosition = new Vector3(widgetPosX, widgetPosY, 0f);
			DreamOSDataManager.WriteFloatData(dataCat, ID + "_PosX", widgetPosX);
			DreamOSDataManager.WriteFloatData(dataCat, ID + "_PosY", widgetPosY);
		}

		private IEnumerator DisableObject()
		{
			yield return new WaitForSeconds(cachedAnimatorLength);
			base.gameObject.SetActive(value: false);
		}

		private IEnumerator DisableAnimator()
		{
			yield return new WaitForSeconds(cachedAnimatorLength);
			widgetAnimator.enabled = false;
		}
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TabletAppMail : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CMenuShowCoroutine_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TabletAppMail _003C_003E4__this;

		public RectTransform obj;

		public float toX;

		public float time;

		private float _003CelapsedTime_003E5__2;

		private Vector2 _003CstartPos_003E5__3;

		private Vector2 _003CtargetPos_003E5__4;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CMenuShowCoroutine_003Ed__43(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("Window Components")]
	public TabletAppAnimationWindow tabletAppAnimationWindow;

	[Header("Component")]
	public UsersDatabases usersDatabases;

	public Transform mailPrefabs;

	public Transform mailList;

	public GameObject trash;

	public GameObject menuCategory;

	public GameObject noNetworkInformation;

	[Header("UI")]
	public Transform FullMessage;

	public TextMeshProUGUI FM_name;

	public TextMeshProUGUI FM_from;

	public TextMeshProUGUI FM_to;

	public TextMeshProUGUI FM_title;

	public TextMeshProUGUI FM_contents;

	public string FM_webAddress;

	public int FM_idPDF;

	[SerializeField]
	public TextMeshProUGUI gen_txt;

	[SerializeField]
	public TextMeshProUGUI imp_txt;

	[SerializeField]
	public TextMeshProUGUI del_txt;

	[SerializeField]
	public TextMeshProUGUI task_txt;

	[SerializeField]
	public TextMeshProUGUI job_txt;

	[SerializeField]
	public TextMeshProUGUI spam_txt;

	[SerializeField]
	public Image FM_avatar;

	public GameObject permanentlyDelete;

	[Header("Font Style & Size for description mail")]
	public TMP_FontAsset[] fontAssets;

	[HideInInspector]
	public float fontSize;

	[HideInInspector]
	public int fontStyle;

	[Header("Variable")]
	public string activeTagMail;

	public string hexColorGray;

	public string hexColorBlue;

	public Color newColorGray;

	public Color newColorBlue;

	private Mail nowOpenedMail;

	private bool isMenuOpen;

	private bool isCoroutineEnded;

	private Coroutine showorhideMenuCoroutine;

	public RectTransform menuObject;

	[HideInInspector]
	public bool isOpenMailApp;

	public void OpenApp()
	{
	}

	public void CloseApp()
	{
	}

	public int CountMailsByTag(string tag)
	{
		return 0;
	}

	public void CountAllMails()
	{
	}

	public void OpenCategoryList()
	{
	}

	public void CloseCategoryList()
	{
	}

	[IteratorStateMachine(typeof(_003CMenuShowCoroutine_003Ed__43))]
	private IEnumerator MenuShowCoroutine(RectTransform obj, float fromX, float toX, float time)
	{
		return null;
	}

	public void RenderMail(string type)
	{
	}

	public void RenderListMail(List<Mail> mails, string type)
	{
	}

	public void OpenMail(Mail mail)
	{
	}

	public void CloseButton()
	{
	}

	public void DeleteButton()
	{
	}

	public void RemoveDeletedMail()
	{
	}

	public void ClearMail()
	{
	}

	public void SetFontForContentMail()
	{
	}

	public void SetPaletteCollor()
	{
	}
}

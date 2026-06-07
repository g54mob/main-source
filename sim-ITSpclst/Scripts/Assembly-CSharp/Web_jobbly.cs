using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Web_jobbly : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CsendCV_003Ed__37 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Web_jobbly _003C_003E4__this;

		public Offert offer;

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
		public _003CsendCV_003Ed__37(int _003C_003E1__state)
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

	public AppBrowser appBrowser;

	public GameObject jobOfferPrefab;

	public Transform jobContainer;

	public string defaultTag;

	public string nowTag;

	public bool isIT;

	public Sprite[] d_logos_company;

	[SerializeField]
	public TMP_InputField addressText;

	[Header("Animacje")]
	public GameObject[] kropki;

	public TextMeshProUGUI[] category_name;

	public NotificationManager notificationManager;

	public MailBase mailbase;

	public gameManager gManager;

	public GameObject buttonSendCV;

	public GameObject buttonVisitAvocado;

	public Button ButtonSendCV;

	public Button ButtonVisitAvocado;

	private int sendCvCounter;

	public GameObject offerDetailsPanel;

	public TextMeshProUGUI detailJobTitle;

	public TextMeshProUGUI detailCompanyName;

	public TextMeshProUGUI detailSalary;

	public TextMeshProUGUI detailLocation;

	public TextMeshProUGUI detailExperienceLevel;

	public TextMeshProUGUI desc_main;

	public TextMeshProUGUI desc_01;

	public TextMeshProUGUI desc_02;

	public TextMeshProUGUI desc_03;

	public Image detailLogo;

	public int SendCvCounter { get; set; }

	public void DisplayOffersByTag(string tag, string link, int id_button)
	{
	}

	public void ShowOfferDetails(Offert offer)
	{
	}

	public void SendCVtoEmployer(Offert offer)
	{
	}

	public void VisitAvocado()
	{
	}

	[IteratorStateMachine(typeof(_003CsendCV_003Ed__37))]
	public IEnumerator sendCV(Offert offer)
	{
		return null;
	}

	public void CloseOfferDetails()
	{
	}

	public void ResetCategroyName()
	{
	}

	public void SetCategoryName(int id_button)
	{
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class systeminstalation : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CAnimateToPositionViewOne_003Ed__82 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public systeminstalation _003C_003E4__this;

		public Vector3 targetPosition;

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
		public _003CAnimateToPositionViewOne_003Ed__82(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CstatusInstall_003Ed__78 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public systeminstalation _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CstatusInstall_003Ed__78(int _003C_003E1__state)
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

	[CompilerGenerated]
	private sealed class _003CstatusRepair_003Ed__79 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public systeminstalation _003C_003E4__this;

		private int _003Ci_003E5__2;

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
		public _003CstatusRepair_003Ed__79(int _003C_003E1__state)
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

	public yourComputerInSmallCorp urComp;

	public ComputerFrontPort computerFrontPort;

	public DirectoryManager directoryManager;

	public WarningDatabase warningDatabase;

	[Header("Gameobject")]
	public GameObject systemInstallObject;

	public GameObject[] View;

	public GameObject[] BackGroundButtonSystemVersion;

	public GameObject[] BackGroundButtonDisc;

	public GameObject buttonNextInView03;

	public GameObject animfirstShow;

	public GameObject crosView4;

	public GameObject buttonNextInView04;

	public GameObject buttonNextInView06;

	public GameObject firstRunView;

	public TextMeshProUGUI firstRunText;

	[Header("Jeżeli jest zaisntalowany system")]
	public GameObject RepairButton;

	[Header("Components")]
	public string[] firstRunTextArray;

	[SerializeField]
	private Transform partitionListContainer;

	[SerializeField]
	private GameObject partitionPrefab;

	private List<DataDiskPartition> partitions;

	public Button buttonFormat;

	private DataDiskPartition selectedPartition;

	private partitionDiskAdapter selectedPartitionAdapter;

	private bool isSelectSystemVersion;

	private bool viewFourCheckBox;

	private bool isSelectDisc;

	private int discSelected;

	public bool diskOneFormated;

	public bool diskTwoFormated;

	public TextMeshProUGUI DiscOneName;

	public TextMeshProUGUI FreeSpaceOne;

	public TextMeshProUGUI FreeSpaceTwo;

	public TextMeshProUGUI Refresh;

	public TextMeshProUGUI Deleted;

	public TextMeshProUGUI Format;

	public Image RefreshImage;

	public Image DeletedImage;

	public Image FormatImage;

	private string hexColorGrayInstallSystem;

	private Color newColorGrayInstallSystem;

	[Header("Instalacja")]
	public GameObject[] ImageInstallData;

	public TextMeshProUGUI[] TextInstallData;

	public Coroutine install;

	[Header("Repair")]
	public GameObject[] ImageRepairData;

	public TextMeshProUGUI[] TextRepairData;

	public Coroutine repair;

	[Header("Animation First View")]
	public RectTransform firstViewAnim;

	public float animationDuration;

	private Vector3 startPositionV1;

	private Vector3 hiddenPositionV1;

	private float elapsedTimeV1;

	public Coroutine animOne;

	public int portBootDevice;

	public SystemInstalationAfterSetup SystemInstalationAfterSetup;

	public void isStillUsb()
	{
	}

	public void GoView01()
	{
	}

	public void GoNext_02()
	{
	}

	public void GoNext_03()
	{
	}

	public void GoNext_04()
	{
	}

	public void GoNext_05()
	{
	}

	public void GoNext_07()
	{
	}

	public void GoNext_Repair_One()
	{
	}

	public void SelectVersionOne()
	{
	}

	public void SelectVersionTwo()
	{
	}

	public void GoNext_06()
	{
	}

	public void RefreshPartitionList()
	{
	}

	private void ClearPartitionUI()
	{
	}

	private void SelectPartition(partitionDiskAdapter adapter, DataDiskPartition partition)
	{
	}

	private void FormatSelectedPartition()
	{
	}

	public void RefreshDisc()
	{
	}

	public void SetGrayButtonDisc()
	{
	}

	public void SetPaletteCollor()
	{
	}

	public void CheckboxViewFour()
	{
	}

	public void ResetSevenViewTextandImage()
	{
	}

	public void ResetEightViewTextandImage()
	{
	}

	public void ResetAllView()
	{
	}

	public void ResetAllButtonForView03()
	{
	}

	public void ResetAllButtonForView06()
	{
	}

	[IteratorStateMachine(typeof(_003CstatusInstall_003Ed__78))]
	private IEnumerator statusInstall()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CstatusRepair_003Ed__79))]
	private IEnumerator statusRepair()
	{
		return null;
	}

	public void GetAppsAndFile()
	{
	}

	public void InstallWrongFile()
	{
	}

	[IteratorStateMachine(typeof(_003CAnimateToPositionViewOne_003Ed__82))]
	private IEnumerator AnimateToPositionViewOne(Vector3 targetPosition)
	{
		return null;
	}

	public void PrepareFileSystem()
	{
	}

	private void FormatSystemPartition()
	{
	}
}

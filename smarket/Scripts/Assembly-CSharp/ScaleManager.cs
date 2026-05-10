using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

public class ScaleManager : NoktaSingleton<ScaleManager>
{
	private List<Scale> m_Scales;

	private List<ScaleData> m_Data;

	public List<ScaleData> Data
	{
		get
		{
			return null;
		}
		private set
		{
		}
	}

	public bool IsLoaded { get; private set; }

	public int ScaleCount => 0;

	public bool HasAnyScale => false;

	public bool HasAvailableQueue => false;

	public event Action<Scale> ScaleRemoved
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event Action ScaleCountChanged
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event EventHandler ScaleBarcodeCreated
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event EventHandler ScaleBarcodeApplied
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event EventHandler ScaleCustomerCompleted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event EventHandler ScaleCustomerProductCreated
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event EventHandler ScaleBarcodeDragStarted
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	public event EventHandler ScaleBarcodeDragEnded
	{
		[CompilerGenerated]
		add
		{
		}
		[CompilerGenerated]
		remove
		{
		}
	}

	private void Awake()
	{
	}

	private void LoadSaveProgress()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void InvokeScaleProductCreated(Scale scale)
	{
	}

	public void InvokeScaleCustomerCompleted(Scale scale)
	{
	}

	public void InvokeScaleBarcodeDragStarted(Scale scale)
	{
	}

	public void InvokeScaleBarcodeDragEnded(Scale scale)
	{
	}

	public void InvokeScaleBarcodeCreated(Scale scale)
	{
	}

	public void InvokeScaleBarcodeApplied(Scale scale)
	{
	}

	private void OnDayFinished()
	{
	}

	private void ResetScales()
	{
	}

	private void Setup()
	{
	}

	private void LoadData()
	{
	}

	public void AddScale(Scale scale)
	{
	}

	public void RemoveScale(Scale scale)
	{
	}

	private void RepopulateData()
	{
	}

	public Scale GetAvailableScale()
	{
		return null;
	}

	public bool HasScale()
	{
		return false;
	}

	public IEnumerable<Scale> GetIterator()
	{
		return null;
	}
}

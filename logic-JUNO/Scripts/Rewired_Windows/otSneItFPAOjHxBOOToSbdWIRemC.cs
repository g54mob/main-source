using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class otSneItFPAOjHxBOOToSbdWIRemC : IDisposable
{
	[CompilerGenerated]
	private EventHandler<EventArgs> m_qLSdYlYEsgDJYGEJgAuBbdodDTaYA;

	[CompilerGenerated]
	private EventHandler<EventArgs> m_dqNSRTPJfdMagJNzuYeqsPwTKuQn;

	[CompilerGenerated]
	private bool LOAxkAggDRuiaHiygPDyNxkidXuH;

	public bool ymJSqxrYRXlzmbgynBQRDSQvxvtE
	{
		[CompilerGenerated]
		get
		{
			return LOAxkAggDRuiaHiygPDyNxkidXuH;
		}
		[CompilerGenerated]
		private set
		{
			LOAxkAggDRuiaHiygPDyNxkidXuH = lOAxkAggDRuiaHiygPDyNxkidXuH;
		}
	}

	public event EventHandler<EventArgs> qLSdYlYEsgDJYGEJgAuBbdodDTaYA
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_qLSdYlYEsgDJYGEJgAuBbdodDTaYA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_qLSdYlYEsgDJYGEJgAuBbdodDTaYA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_qLSdYlYEsgDJYGEJgAuBbdodDTaYA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_qLSdYlYEsgDJYGEJgAuBbdodDTaYA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> dqNSRTPJfdMagJNzuYeqsPwTKuQn
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_dqNSRTPJfdMagJNzuYeqsPwTKuQn;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_dqNSRTPJfdMagJNzuYeqsPwTKuQn, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_dqNSRTPJfdMagJNzuYeqsPwTKuQn;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_dqNSRTPJfdMagJNzuYeqsPwTKuQn, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void uIjynijFiWcxEezCtKbvnpcocUUSA()
	{
		try
		{
			LsALnFZPtQddfFxqHiIpqXCVWKTM(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public void Dispose()
	{
		LsALnFZPtQddfFxqHiIpqXCVWKTM(true);
	}

	void IDisposable.Dispose()
	{
		//ILSpy generated this explicit interface implementation from .override directive in Dispose
		this.Dispose();
	}

	private void LsALnFZPtQddfFxqHiIpqXCVWKTM(bool P_0)
	{
		if (!ymJSqxrYRXlzmbgynBQRDSQvxvtE)
		{
			this.qLSdYlYEsgDJYGEJgAuBbdodDTaYA?.Invoke(this, EventArgs.Empty);
			CUwNmPdbPZwkmbbiFHXgCkXMomOx(P_0);
			GC.SuppressFinalize(this);
			ymJSqxrYRXlzmbgynBQRDSQvxvtE = true;
			this.dqNSRTPJfdMagJNzuYeqsPwTKuQn?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void CUwNmPdbPZwkmbbiFHXgCkXMomOx(bool P_0);
}

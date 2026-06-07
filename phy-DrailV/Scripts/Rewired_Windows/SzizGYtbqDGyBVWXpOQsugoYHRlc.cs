using System;
using System.Runtime.CompilerServices;
using System.Threading;

internal abstract class SzizGYtbqDGyBVWXpOQsugoYHRlc : IDisposable
{
	[CompilerGenerated]
	private EventHandler<EventArgs> m_CxJyRmUnVUelgCqomMuaxONaGXLdb;

	[CompilerGenerated]
	private EventHandler<EventArgs> m_tdriNmbhXnPhCACLuKgooXNcQLtoA;

	[CompilerGenerated]
	private bool qoavDbtzaclEzMVLtxtwBYsEWnMA;

	public bool RIGgzpMoERJFtFOPrfiOWcNmzkni
	{
		[CompilerGenerated]
		get
		{
			return qoavDbtzaclEzMVLtxtwBYsEWnMA;
		}
		[CompilerGenerated]
		private set
		{
			qoavDbtzaclEzMVLtxtwBYsEWnMA = flag;
		}
	}

	public event EventHandler<EventArgs> CxJyRmUnVUelgCqomMuaxONaGXLdb
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_CxJyRmUnVUelgCqomMuaxONaGXLdb;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_CxJyRmUnVUelgCqomMuaxONaGXLdb, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_CxJyRmUnVUelgCqomMuaxONaGXLdb;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_CxJyRmUnVUelgCqomMuaxONaGXLdb, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	public event EventHandler<EventArgs> tdriNmbhXnPhCACLuKgooXNcQLtoA
	{
		[CompilerGenerated]
		add
		{
			EventHandler<EventArgs> eventHandler = this.m_tdriNmbhXnPhCACLuKgooXNcQLtoA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Combine(eventHandler2, b);
				eventHandler = Interlocked.CompareExchange(ref this.m_tdriNmbhXnPhCACLuKgooXNcQLtoA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			EventHandler<EventArgs> eventHandler = this.m_tdriNmbhXnPhCACLuKgooXNcQLtoA;
			EventHandler<EventArgs> eventHandler2;
			do
			{
				eventHandler2 = eventHandler;
				EventHandler<EventArgs> value2 = (EventHandler<EventArgs>)Delegate.Remove(eventHandler2, value3);
				eventHandler = Interlocked.CompareExchange(ref this.m_tdriNmbhXnPhCACLuKgooXNcQLtoA, value2, eventHandler2);
			}
			while ((object)eventHandler != eventHandler2);
		}
	}

	protected virtual void pYlnYOlzFvvuMmuHFoPfbQwWCYmO()
	{
		try
		{
			lBgPuWARJIpDWUqmPKESIttqlFDF(false);
		}
		finally
		{
			base.Finalize();
		}
	}

	public void Dispose()
	{
		lBgPuWARJIpDWUqmPKESIttqlFDF(true);
	}

	private void lBgPuWARJIpDWUqmPKESIttqlFDF(bool P_0)
	{
		if (!RIGgzpMoERJFtFOPrfiOWcNmzkni)
		{
			this.CxJyRmUnVUelgCqomMuaxONaGXLdb?.Invoke(this, EventArgs.Empty);
			vCBFvIdHsbAnKBZkroQOsRrLIAyV(P_0);
			GC.SuppressFinalize(this);
			RIGgzpMoERJFtFOPrfiOWcNmzkni = true;
			this.tdriNmbhXnPhCACLuKgooXNcQLtoA?.Invoke(this, EventArgs.Empty);
		}
	}

	protected abstract void vCBFvIdHsbAnKBZkroQOsRrLIAyV(bool P_0);
}

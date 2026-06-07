using System;
using UnityEngine;

public class AkAuxSendArray : IDisposable
{
	private const int MAX_COUNT = 4;

	private readonly int SIZE_OF_AKAUXSENDVALUE;

	private IntPtr m_Buffer;

	private int m_Count;

	public AkAuxSendValue this[int index] => null;

	public bool isFull => false;

	public void Dispose()
	{
	}

	~AkAuxSendArray()
	{
	}

	public void Reset()
	{
	}

	public bool Add(GameObject in_listenerGameObj, uint in_AuxBusID, float in_fValue)
	{
		return false;
	}

	public bool Add(uint in_AuxBusID, float in_fValue)
	{
		return false;
	}

	public bool Contains(GameObject in_listenerGameObj, uint in_AuxBusID)
	{
		return false;
	}

	public bool Contains(uint in_AuxBusID)
	{
		return false;
	}

	public AKRESULT SetValues(GameObject gameObject)
	{
		return default(AKRESULT);
	}

	public AKRESULT GetValues(GameObject gameObject)
	{
		return default(AKRESULT);
	}

	public IntPtr GetBuffer()
	{
		return (IntPtr)0;
	}

	public int Count()
	{
		return 0;
	}

	private IntPtr GetObjectPtr(int index)
	{
		return (IntPtr)0;
	}
}

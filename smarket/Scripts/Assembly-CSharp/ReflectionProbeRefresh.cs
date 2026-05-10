using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ReflectionProbe))]
public class ReflectionProbeRefresh : MonoBehaviour
{
	[SerializeField]
	private int m_HourToStartRefreshing;

	[SerializeField]
	private bool m_AM;

	[SerializeField]
	private float m_RefreshRate;

	[SerializeField]
	private bool m_IsDynamic;

	public List<TimeProbeData> ProbeDatas;

	private int m_CurrentDataIndex;

	private ReflectionProbe m_ReflectionProbe;

	private bool m_Refresh;

	private float m_LastRefreshTime;

	public bool IsDynamic => false;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	private void CheckTime()
	{
	}

	public void ManualUpdate()
	{
	}

	private void RefreshProbe()
	{
	}

	public void RefreshProbe(int index)
	{
	}

	private void OnDayCycleDisabled()
	{
	}
}

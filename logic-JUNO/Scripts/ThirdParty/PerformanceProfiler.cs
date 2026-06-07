using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PerformanceProfiler : MonoBehaviour
{
	public bool _bSkip;

	public bool _bRunInParrelel = true;

	public Transform _trnSpawnArea;

	public float _fSpawnVariance;

	public Transform _trnProfileTarget1;

	public Transform _trnProfileTarget2;

	public int _iNumberOfLevels;

	public int _iStartNumber;

	public int _iIncreasePerLevel;

	public float _fTimePerLevel;

	public float _fSettleTime;

	public int _fSettleFrames;

	public List<float> _lstTarget1FrameRate;

	public List<float> _lstTarget2FrameRate;

	public UnityEvent _evtOnProfileFinish;

	public void SpawnObjects(Transform trnObjectToSpawn, int iNumberToSpawn)
	{
		for (int i = 0; i < iNumberToSpawn; i++)
		{
			Object.Instantiate(trnObjectToSpawn, _trnSpawnArea.position + new Vector3(Random.Range(0f - _fSpawnVariance, _fSpawnVariance), Random.Range(0f - _fSpawnVariance, _fSpawnVariance), Random.Range(0f - _fSpawnVariance, _fSpawnVariance)), Quaternion.identity, _trnSpawnArea);
		}
	}

	public void CleanUpSpawnedObjects()
	{
		foreach (Transform item in _trnSpawnArea)
		{
			Object.Destroy(item.gameObject);
		}
	}

	public IEnumerator RunLevel(List<float> lstResultList, int iResultIndex, int iSpawnCount, Transform trnTargetObject)
	{
		CleanUpSpawnedObjects();
		SpawnObjects(trnTargetObject, iSpawnCount);
		yield return new WaitForSeconds(_fSettleTime);
		for (int i = 0; i < _fSettleFrames; i++)
		{
			yield return null;
		}
		float fStartTime = Time.realtimeSinceStartup;
		int iFrames = 0;
		while (Time.realtimeSinceStartup - fStartTime < _fTimePerLevel)
		{
			iFrames++;
			yield return null;
		}
		float num = Time.realtimeSinceStartup - fStartTime;
		float value = (float)iFrames / num;
		lstResultList[iResultIndex] = value;
		yield return null;
	}

	public IEnumerator RunProfile()
	{
		_lstTarget1FrameRate = new List<float>(_iNumberOfLevels);
		_lstTarget2FrameRate = new List<float>(_iNumberOfLevels);
		while (_lstTarget1FrameRate.Count < _iNumberOfLevels)
		{
			_lstTarget1FrameRate.Add(0f);
		}
		while (_lstTarget2FrameRate.Count < _iNumberOfLevels)
		{
			_lstTarget2FrameRate.Add(0f);
		}
		for (int i = 0; i < _iNumberOfLevels; i++)
		{
			int iNumberOfItems = (i + 1) * _iIncreasePerLevel + _iStartNumber;
			yield return StartCoroutine(RunLevel(_lstTarget1FrameRate, i, iNumberOfItems, _trnProfileTarget1));
			if (_bRunInParrelel)
			{
				yield return StartCoroutine(RunLevel(_lstTarget2FrameRate, i, iNumberOfItems, _trnProfileTarget2));
			}
		}
		if (!_bRunInParrelel)
		{
			for (int i = 0; i < _iNumberOfLevels; i++)
			{
				int iSpawnCount = (i + 1) * _iIncreasePerLevel + _iStartNumber;
				yield return StartCoroutine(RunLevel(_lstTarget2FrameRate, i, iSpawnCount, _trnProfileTarget2));
			}
		}
		CleanUpSpawnedObjects();
		_evtOnProfileFinish.Invoke();
	}

	public void StartProfiling()
	{
		StartCoroutine(RunProfile());
	}
}

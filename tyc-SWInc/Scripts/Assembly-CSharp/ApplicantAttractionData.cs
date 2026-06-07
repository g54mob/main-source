using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ApplicantAttractionData
{
	[Serializable]
	public class RollingValue
	{
		public float[] Values;

		public int _index;

		public RollingValue()
		{
		}

		public RollingValue(int values)
		{
			Values = new float[values];
			for (int i = 0; i < values; i++)
			{
				Values[i] = -1f;
			}
		}

		public void AddValue(float value)
		{
			Values[_index] = value;
			_index = (_index + 1) % Values.Length;
		}

		public float GetAverage(float defaultValue = 0f)
		{
			int num = 0;
			float num2 = 0f;
			for (int i = 0; i < Values.Length; i++)
			{
				if (Values[i] >= 0f)
				{
					num++;
					num2 += Values[i];
				}
			}
			if (num <= 0)
			{
				return defaultValue;
			}
			return num2 / (float)num;
		}
	}

	public float TaxFraud;

	private float[] _appealData = new float[3] { 1f, 1f, 1f };

	private RollingValue _turnOver = new RollingValue(12);

	private RollingValue _satisfaction = new RollingValue(12);

	private List<float> _fireSeniority = new List<float>();

	private int[] _layoffs = new int[24]
	{
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1, -1, -1, -1, -1, -1, -1,
		-1, -1, -1, -1
	};

	private int _layoffIndex;

	private SDateTime _lastLayoff = new SDateTime(0);

	private float _layoffScore;

	private float _currentSatisfaction;

	private int _satisfactionCount;

	public float TaxFraudEffect
	{
		get
		{
			return TaxFraud.MapRange(0f, 1f, 1f, 0.5f);
		}
	}

	public void TurnMonth()
	{
		int num = 0;
		float num2 = 0f;
		SDateTime now = SDateTime.Now();
		for (int i = 0; i < GameSettings.Instance.sActorManager.Actors.Count; i++)
		{
			Actor actor = GameSettings.Instance.sActorManager.Actors[i];
			if (actor.IsAliveNotNull() && !actor.employee.Dismissed && !actor.employee.Founder)
			{
				float years = SDateTime.GetYears(actor.employee.Hired, now);
				if (years >= 5f)
				{
					num++;
					num2 += years;
				}
			}
		}
		num += _fireSeniority.Count;
		num2 += _fireSeniority.SumSafe((float x) => x);
		_fireSeniority.Clear();
		if (num > 0)
		{
			_turnOver.AddValue(num2 / (float)num);
		}
		else
		{
			_turnOver.AddValue(-1f);
		}
		if (_satisfactionCount > 0)
		{
			_satisfaction.AddValue(_currentSatisfaction / (float)_satisfactionCount);
			_currentSatisfaction = 0f;
			_satisfactionCount = 0;
		}
		_layoffScore = Mathf.Max(0f, _layoffScore - 1f / 12f);
		UpdateLayoffIndex();
		UpdateLayoffScore();
		TaxFraud = Mathf.Max(0f, TaxFraud - 1f / 12f);
		_appealData = new float[3]
		{
			GetTurnOverScore(),
			GetLayoffScore(),
			GetSatisfactionScore()
		};
	}

	public ValueTuple<float, float, float, float> GetAppealData()
	{
		return new ValueTuple<float, float, float, float>(_appealData[0], _appealData[1], _appealData[2], TaxFraudEffect);
	}

	public float GetAppeal()
	{
		float num = 1f;
		for (int i = 0; i < _appealData.Length; i++)
		{
			num *= _appealData[i];
		}
		return num * TaxFraudEffect;
	}

	public float GetTurnOverScore()
	{
		float average = _turnOver.GetAverage(-1f);
		if (average >= 0f)
		{
			float years = SDateTime.GetYears(GameSettings.Instance.MyCompany.Founded, SDateTime.Now());
			if (years == 0f)
			{
				return 1f;
			}
			if (years >= 5f)
			{
				return Mathf.Clamp01(average / 5f).WeightOne(0.5f);
			}
			return (average / years).MapRange(0f, 1f, Mathf.Lerp(1f, 0.5f, years / 5f), 1f);
		}
		return 1f;
	}

	public float GetSatisfactionScore()
	{
		float average = _satisfaction.GetAverage(-1f);
		if (!(average >= 0f))
		{
			return 1f;
		}
		return average.MapRange(0f, 1f, 0.25f, 1f, true);
	}

	public float GetLayoffScore()
	{
		return _layoffScore.MapRange(0f, 1f, 1f, 0.25f, true);
	}

	public float GetAwardScore()
	{
		List<Actor> list = GameSettings.Instance.sActorManager.Actors.Where((Actor actor) => !actor.employee.Founder).ToList();
		float x = list.Average((Actor actor) => SDateTime.GetYears(actor.employee.Hired, SDateTime.Now()));
		float b = Mathf.Clamp(SDateTime.GetYears(GameSettings.Instance.MyCompany.Founded, SDateTime.Now()), 2f, 5f);
		float num = x.MapRange(1f, b, 0.8f, 1f, true);
		float number = Mathf.Clamp01(list.Average((Actor actor) => actor.GetBenefitScore()) / 0.65f);
		float num2 = list.Count.MapRange(5f, 10f, 0f, 1f, true);
		float num3 = Mathf.Clamp01(_satisfaction.GetAverage(-1f));
		float turnOverScore = GetTurnOverScore();
		return number.WeightOne(0.5f) * num * num2 * num3 * turnOverScore;
	}

	public void NoteFiring(Employee e)
	{
		float years = SDateTime.GetYears(e.Hired, SDateTime.Now());
		if (!(years < 1f / (float)(GameSettings.DaysPerMonth * 12 * 3)))
		{
			_fireSeniority.Add(years);
			UpdateLayoffIndex();
			_layoffs[_layoffIndex]++;
			UpdateLayoffScore();
		}
	}

	private void UpdateLayoffIndex()
	{
		SDateTime sDateTime = SDateTime.Now();
		if (_lastLayoff.Year != sDateTime.Year || _lastLayoff.Month != sDateTime.Month || _lastLayoff.Day != sDateTime.Day || _lastLayoff.Hour != sDateTime.Hour)
		{
			int hoursFlat = SDateTime.GetHoursFlat(_lastLayoff, sDateTime);
			if (hoursFlat >= 24)
			{
				_layoffIndex = 0;
				for (int i = 0; i < _layoffs.Length; i++)
				{
					_layoffs[i] = 0;
				}
			}
			else
			{
				int layoffIndex = _layoffIndex;
				_layoffIndex = (_layoffIndex + hoursFlat) % _layoffs.Length;
				for (int num = (layoffIndex + 1) % _layoffs.Length; num != _layoffIndex; num = (num + 1) % _layoffs.Length)
				{
					_layoffs[num] = 0;
				}
				_layoffs[_layoffIndex] = 0;
			}
		}
		_lastLayoff = sDateTime;
	}

	private void UpdateLayoffScore()
	{
		int num = 0;
		for (int i = 0; i < _layoffs.Length; i++)
		{
			if (_layoffs[i] > 0)
			{
				num += _layoffs[i];
			}
		}
		int num2 = Mathf.Max(20, num + GameSettings.Instance.sActorManager.Actors.Count((Actor x) => !x.employee.Founder));
		float num3 = (float)num / (float)num2;
		if (num3 > 0.05f)
		{
			_layoffScore = Mathf.Max(_layoffScore, Mathf.Clamp01(num3 / 0.25f));
		}
	}

	public void NoteSatisfaction(float satisfaction)
	{
		_currentSatisfaction += satisfaction;
		_satisfactionCount++;
	}
}

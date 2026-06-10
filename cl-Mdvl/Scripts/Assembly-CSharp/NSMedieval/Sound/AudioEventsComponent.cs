using System.Collections.Generic;
using System.Text.RegularExpressions;
using FMOD.Studio;
using FMODUnity;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.Utils.Pool.Janitors;
using UnityEngine;

namespace NSMedieval.Sound
{
	public class AudioEventsComponent : MonoBehaviour
	{
		private readonly Dictionary<string, Dictionary<string, string>> eventNameParameters = new Dictionary<string, Dictionary<string, string>>();

		private readonly Dictionary<string, Dictionary<string, float>> eventValueParameters = new Dictionary<string, Dictionary<string, float>>();

		private readonly Dictionary<string, EventInstance> eventInstances = new Dictionary<string, EventInstance>();

		public void SetEventParameters(string eventId, PooledDictionary<string, string> parameters)
		{
			Dictionary<string, string> dictionary = GetEventNameParameters(eventId);
			foreach (KeyValuePair<string, string> item in parameters)
			{
				dictionary[item.Key] = item.Value;
			}
			ApplyEventParameters(eventId);
		}

		public void SetEventParameters(string eventId, Dictionary<string, string> parameters)
		{
			Dictionary<string, string> dictionary = GetEventNameParameters(eventId);
			foreach (KeyValuePair<string, string> parameter in parameters)
			{
				dictionary[parameter.Key] = parameter.Value;
			}
			ApplyEventParameters(eventId);
		}

		public void SetEventParameters(string eventId, Dictionary<string, float> parameters)
		{
			Dictionary<string, float> dictionary = GetEventValueParameters(eventId);
			foreach (KeyValuePair<string, float> parameter in parameters)
			{
				dictionary[parameter.Key] = parameter.Value;
			}
			ApplyEventParameters(eventId);
		}

		public void SetEventParameter(string eventId, string key, float value)
		{
			GetEventValueParameters(eventId)[key] = value;
			ApplyEventParameters(eventId);
		}

		public void SetEventParameter(string eventId, KeyValuePair<string, float> parameter)
		{
			GetEventValueParameters(eventId)[parameter.Key] = parameter.Value;
			ApplyEventParameters(eventId);
		}

		public void PlayEventInstanceAtPosition(string eventId, Vector3 position)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(28, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsComponent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("PlayEventInstance ");
				messageBuilder.AppendFormatted(base.gameObject.name);
				messageBuilder.AppendLiteral(" event id ");
				messageBuilder.AppendFormatted(eventId);
			}
			Log.Trace(messageBuilder);
			if (!eventInstances.ContainsKey(eventId))
			{
				eventInstances.Add(eventId, RuntimeManager.CreateInstance(MonoRepository<SoundRepository, SoundEvent>.Instance.GetPathByID(eventId)));
			}
			PlayEventHandler(eventId, position);
		}

		public void PlayEventInstance(string eventId)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(28, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsComponent.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("PlayEventInstance ");
				messageBuilder.AppendFormatted(base.gameObject.name);
				messageBuilder.AppendLiteral(" event id ");
				messageBuilder.AppendFormatted(eventId);
			}
			Log.Trace(messageBuilder);
			PlayEventInstanceAtPosition(eventId, base.transform.position);
		}

		public void StopEventInstance(string eventId)
		{
			if (eventInstances.TryGetValue(eventId, out var value))
			{
				value.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			}
		}

		public void KeyOffEventInstance(string eventId)
		{
			if (eventInstances.TryGetValue(eventId, out var value))
			{
				value.keyOff();
			}
		}

		public void StopAllInstances()
		{
			foreach (EventInstance value in eventInstances.Values)
			{
				value.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
			}
		}

		public void PlayEventParameters(string text)
		{
			Match match = new Regex("^(.*?)\\[(.*?)\\]$").Match(text);
			bool isEnabled;
			if (!match.Success)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(47, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("PlayEventParameters ");
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(". Couldn't regex match '");
					messageBuilder.AppendFormatted(text);
					messageBuilder.AppendLiteral("' !");
				}
				Log.Error(messageBuilder);
				return;
			}
			string value = match.Groups[1].Value;
			string value2 = match.Groups[2].Value;
			FVLogTraceInterpolationHandler messageBuilder2 = new FVLogTraceInterpolationHandler(27, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsComponent.cs");
			if (isEnabled)
			{
				messageBuilder2.AppendLiteral("PlayEventParameters ");
				messageBuilder2.AppendFormatted(value);
				messageBuilder2.AppendLiteral(" param ");
				messageBuilder2.AppendFormatted(value2);
			}
			Log.Trace(messageBuilder2);
			string[] array = value2.Split(',');
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string[] array3 = array2[i].Split(':');
				if (!float.TryParse(array3[1], out var result))
				{
					Log.Error("Could not parse value: " + array3[1] + " to float", "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsComponent.cs");
				}
				else
				{
					dictionary.Add(array3[0], result);
				}
			}
			SetEventParameters(value, dictionary);
			PlayEvent(value);
		}

		public void PlayEvent(string eventId)
		{
			PlayEvent(eventId, base.transform.position);
		}

		public void PlayEvent(string eventId, Vector3 position)
		{
			if (string.IsNullOrWhiteSpace(eventId))
			{
				bool isEnabled;
				FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(29, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Managers\\AudioEventsComponent.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Animation on ");
					messageBuilder.AppendFormatted(base.gameObject.name);
					messageBuilder.AppendLiteral(" has no event id");
				}
				Log.Debug(messageBuilder);
			}
			else if (eventInstances.ContainsKey(eventId))
			{
				PlayEventHandler(eventId, base.transform.position);
			}
			else
			{
				MonoSingleton<AudioManager>.Instance.PlaySoundAtPosition(eventId, base.transform.position);
			}
		}

		protected void SetEventInstanceParameters(string eventId, EventInstance eventInstance)
		{
			if (!eventValueParameters.ContainsKey(eventId))
			{
				return;
			}
			foreach (KeyValuePair<string, float> item in eventValueParameters[eventId])
			{
				eventInstance.setParameterByName(item.Key, item.Value);
			}
		}

		private void PlayEventHandler(string eventId, Vector3 position)
		{
			EventInstance eventInstance = eventInstances[eventId];
			if (position == Vector3.zero)
			{
				position = base.transform.position;
			}
			eventInstance.set3DAttributes(position.To3DAttributes());
			ApplyEventParameters(eventId);
			eventInstance.start();
		}

		private void ApplyEventParameters(string eventId)
		{
			EventInstance eventInstance = eventInstances[eventId];
			if (eventValueParameters.TryGetValue(eventId, out var value))
			{
				foreach (KeyValuePair<string, float> item in value)
				{
					eventInstance.setParameterByName(item.Key, item.Value);
				}
			}
			if (!eventNameParameters.TryGetValue(eventId, out var value2))
			{
				return;
			}
			foreach (KeyValuePair<string, string> item2 in value2)
			{
				eventInstance.setParameterByNameWithLabel(item2.Key, item2.Value);
			}
		}

		private Dictionary<string, string> GetEventNameParameters(string eventId)
		{
			if (eventNameParameters.TryGetValue(eventId, out var value))
			{
				return value;
			}
			if (!eventInstances.ContainsKey(eventId))
			{
				eventInstances.Add(eventId, RuntimeManager.CreateInstance(MonoRepository<SoundRepository, SoundEvent>.Instance.GetPathByID(eventId)));
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			eventNameParameters[eventId] = dictionary;
			return dictionary;
		}

		private Dictionary<string, float> GetEventValueParameters(string eventId)
		{
			if (eventValueParameters.ContainsKey(eventId))
			{
				return eventValueParameters[eventId];
			}
			if (!eventInstances.ContainsKey(eventId))
			{
				eventInstances.Add(eventId, RuntimeManager.CreateInstance(MonoRepository<SoundRepository, SoundEvent>.Instance.GetPathByID(eventId)));
			}
			Dictionary<string, float> dictionary = new Dictionary<string, float>();
			eventValueParameters[eventId] = dictionary;
			return dictionary;
		}
	}
}

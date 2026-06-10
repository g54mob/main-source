using System;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix.Repository;
using NSMedieval.Serialization;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[FVSerializableKey("SignComponentInstance", "")]
	public class SignComponentInstance : BaseComponentInstance
	{
		[NonSerialized]
		private readonly SignComponentBlueprint blueprint;

		[field: SerializeField]
		public string Message { get; private set; }

		public SignComponentBlueprint Blueprint => blueprint;

		public SignComponentInstance(BaseBuildingInstance ownerBuilding, SignComponentBlueprint blueprint)
			: base(ownerBuilding, blueprint.GetID(), blueprint.ComponentType)
		{
			this.blueprint = blueprint;
			Message = string.Empty;
		}

		public void SetMessage(string message)
		{
			Message = message;
		}

		public override void Dispose()
		{
			if (!base.HasDisposed)
			{
				base.Map.SignComponentManager.RemoveFromCache(this);
				base.Dispose();
			}
		}

		public override void Serialize(FVSerializer serializer)
		{
			base.Serialize(serializer);
			serializer.Write("message", Message);
		}

		public SignComponentInstance(FVDeserializer deserializer)
			: base(deserializer)
		{
			blueprint = Repository<SignComponentRepository, SignComponentBlueprint>.Instance.GetByIdOrDefault(base.ComponentBlueprintID);
			if (blueprint == null)
			{
				bool isEnabled;
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(61, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Constructables\\Building Components\\Signs\\SignComponentInstance.cs");
				if (isEnabled)
				{
					messageBuilder.AppendLiteral("Blueprint could not be found in SignComponentRepository. ID: ");
					messageBuilder.AppendFormatted(base.ComponentBlueprintID);
				}
				Log.Error(messageBuilder);
			}
			else
			{
				Message = deserializer.ReadString("message");
			}
		}
	}
}

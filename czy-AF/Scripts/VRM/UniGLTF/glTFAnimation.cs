using System;
using System.Collections.Generic;
using System.Linq;
using UniJSON;

namespace UniGLTF
{
	[Serializable]
	public class glTFAnimation : JsonSerializableBase
	{
		public string name = "";

		[JsonSchema(Required = true, MinItems = 1)]
		public List<glTFAnimationChannel> channels = new List<glTFAnimationChannel>();

		[JsonSchema(Required = true, MinItems = 1)]
		public List<glTFAnimationSampler> samplers = new List<glTFAnimationSampler>();

		public object extensions;

		public object extras;

		protected override void SerializeMembers(GLTFJsonFormatter f)
		{
			if (!string.IsNullOrEmpty(name))
			{
				f.KeyValue(() => name);
			}
			f.Key("channels");
			f.GLTFValue(channels);
			f.Key("samplers");
			f.GLTFValue(samplers);
		}

		[Obsolete]
		public int AddChannelAndGetSampler(int nodeIndex, glTFAnimationTarget.AnimationPropertys property)
		{
			return AddChannelAndGetSampler(nodeIndex, glTFAnimationTarget.AnimationPropertysToAnimationProperties(property));
		}

		public int AddChannelAndGetSampler(int nodeIndex, glTFAnimationTarget.AnimationProperties property)
		{
			glTFAnimationChannel glTFAnimationChannel2 = channels.FirstOrDefault((glTFAnimationChannel x) => x.target.node == nodeIndex && x.target.path == glTFAnimationTarget.GetPathName(property));
			if (glTFAnimationChannel2 != null)
			{
				return glTFAnimationChannel2.sampler;
			}
			int count = samplers.Count;
			glTFAnimationSampler item = new glTFAnimationSampler();
			samplers.Add(item);
			glTFAnimationChannel2 = new glTFAnimationChannel
			{
				sampler = count,
				target = new glTFAnimationTarget
				{
					node = nodeIndex,
					path = glTFAnimationTarget.GetPathName(property)
				}
			};
			channels.Add(glTFAnimationChannel2);
			return count;
		}
	}
}

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace TH20
{
	public static class CommandBufferUtils
	{
		public static CommandBuffer GetOrCreate(Dictionary<Camera, CommandBuffer> commandBuffers, Camera camera, CameraEvent cameraEvent, string name, bool clear = true)
		{
			CommandBuffer commandBuffer;
			if (commandBuffers.ContainsKey(camera))
			{
				commandBuffer = commandBuffers[camera];
				if (clear)
				{
					commandBuffer.Clear();
				}
			}
			else
			{
				commandBuffer = new CommandBuffer();
				commandBuffer.name = name;
				commandBuffers[camera] = commandBuffer;
				camera.AddCommandBuffer(cameraEvent, commandBuffer);
			}
			return commandBuffer;
		}

		public static CommandBuffer GetOrCreate(Dictionary<Light, CommandBuffer> commandBuffers, Light light, LightEvent lightEvent, string name, bool clear = true)
		{
			CommandBuffer commandBuffer;
			if (commandBuffers.ContainsKey(light))
			{
				commandBuffer = commandBuffers[light];
				if (clear)
				{
					commandBuffer.Clear();
				}
				light.RemoveCommandBuffer(lightEvent, commandBuffer);
				light.AddCommandBuffer(lightEvent, commandBuffer);
			}
			else
			{
				commandBuffer = new CommandBuffer();
				commandBuffer.name = name;
				commandBuffers[light] = commandBuffer;
				light.AddCommandBuffer(lightEvent, commandBuffer);
			}
			return commandBuffer;
		}
	}
}

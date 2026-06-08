using System;
using System.Collections;
using System.Linq;
using HandlebarsDotNet.Compiler;
using HandlebarsDotNet.Iterators;
using HandlebarsDotNet.MemberAccessors;
using HandlebarsDotNet.ObjectDescriptors;
using HandlebarsDotNet.PathStructure;

namespace HandlebarsDotNet
{
	internal class LayoutViewModel
	{
		internal class DescriptorProvider : IObjectDescriptorProvider
		{
			private static readonly object[] BodyProperties = new object[1] { BodyChainSegment };

			private static readonly Type Type = typeof(LayoutViewModel);

			private readonly ObjectDescriptor _descriptor;

			public DescriptorProvider()
			{
				_descriptor = new ObjectDescriptor(Type, new MemberAccessor(), delegate(ObjectDescriptor _, object o)
				{
					LayoutViewModel layoutViewModel = (LayoutViewModel)o;
					IEnumerable source = layoutViewModel._valueDescriptor.GetProperties(layoutViewModel._valueDescriptor, layoutViewModel._value);
					return BodyProperties.Concat(source.Cast<object>());
				}, (ObjectDescriptor _) => new Iterator());
			}

			public bool TryGetDescriptor(Type type, out ObjectDescriptor value)
			{
				if (type != Type)
				{
					value = ObjectDescriptor.Empty;
					return false;
				}
				value = _descriptor;
				return true;
			}
		}

		private class MemberAccessor : IMemberAccessor
		{
			public bool TryGetValue(object instance, ChainSegment memberName, out object value)
			{
				LayoutViewModel layoutViewModel = (LayoutViewModel)instance;
				if (memberName.Equals(BodyChainSegment))
				{
					value = layoutViewModel._body;
					return true;
				}
				IMemberAccessor memberAccessor = layoutViewModel._valueDescriptor.MemberAccessor;
				if (memberAccessor != null)
				{
					return memberAccessor.TryGetValue(layoutViewModel._value, memberName, out value);
				}
				value = null;
				return false;
			}
		}

		private class Iterator : IIterator
		{
			public void Iterate(in EncodedTextWriter writer, BindingContext context, ChainSegment[] blockParamsVariables, object input, TemplateDelegate template, TemplateDelegate ifEmpty)
			{
				LayoutViewModel layoutViewModel = (LayoutViewModel)input;
				layoutViewModel._valueDescriptor.Iterator?.Iterate(in writer, context, blockParamsVariables, layoutViewModel._value, template, ifEmpty);
			}

			void IIterator.Iterate(in EncodedTextWriter writer, BindingContext context, ChainSegment[] blockParamsVariables, object input, TemplateDelegate template, TemplateDelegate ifEmpty)
			{
				Iterate(in writer, context, blockParamsVariables, input, template, ifEmpty);
			}
		}

		private static readonly ChainSegment BodyChainSegment = ChainSegment.Create("body");

		private readonly string _body;

		private readonly object _value;

		private readonly ObjectDescriptor _valueDescriptor;

		public LayoutViewModel(string body, object value)
		{
			_body = body;
			_value = value;
			_valueDescriptor = ObjectDescriptor.Create(value);
		}
	}
}

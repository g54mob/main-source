using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;
using FluentAssertions.Primitives;

namespace FluentAssertions
{
	public static class ObjectAssertionsExtensions
	{
		public static AndConstraint<ObjectAssertions> BeDataContractSerializable(this ObjectAssertions assertions, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			return assertions.BeDataContractSerializable((EquivalencyOptions<object> options) => options, because, becauseArgs);
		}

		public static AndConstraint<ObjectAssertions> BeDataContractSerializable<T>(this ObjectAssertions assertions, Func<EquivalencyOptions<T>, EquivalencyOptions<T>> options, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			Guard.ThrowIfArgumentIsNull(options, "options");
			try
			{
				object obj = CreateCloneUsingDataContractSerializer(assertions.Subject);
				EquivalencyOptions<T> defaultOptions = AssertionConfiguration.Current.Equivalency.CloneDefaults<T>().PreferringRuntimeMemberTypes().IncludingFields()
					.IncludingProperties();
				AssertionExtensions.Should((T)obj).BeEquivalentTo((T)assertions.Subject, (EquivalencyOptions<T> _) => options(defaultOptions), "");
			}
			catch (Exception ex)
			{
				assertions.CurrentAssertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {0} to be serializable{reason}, but serialization failed with:" + Environment.NewLine + Environment.NewLine + "{1}.", assertions.Subject, ex.Message);
			}
			return new AndConstraint<ObjectAssertions>(assertions);
		}

		private static object CreateCloneUsingDataContractSerializer(object subject)
		{
			using MemoryStream memoryStream = new MemoryStream();
			DataContractSerializer dataContractSerializer = new DataContractSerializer(subject.GetType());
			dataContractSerializer.WriteObject(memoryStream, subject);
			memoryStream.Position = 0L;
			return dataContractSerializer.ReadObject(memoryStream);
		}

		public static AndConstraint<ObjectAssertions> BeXmlSerializable(this ObjectAssertions assertions, [StringSyntax("CompositeFormat")] string because = "", params object[] becauseArgs)
		{
			try
			{
				CreateCloneUsingXmlSerializer(assertions.Subject).Should().BeEquivalentTo(assertions.Subject, (EquivalencyOptions<object> options) => options.PreferringRuntimeMemberTypes().IncludingFields().IncludingProperties(), "");
			}
			catch (Exception ex)
			{
				assertions.CurrentAssertionChain.BecauseOf(because, becauseArgs).FailWith("Expected {0} to be serializable{reason}, but serialization failed with:" + Environment.NewLine + Environment.NewLine + "{1}.", assertions.Subject, ex.Message);
			}
			return new AndConstraint<ObjectAssertions>(assertions);
		}

		private static object CreateCloneUsingXmlSerializer(object subject)
		{
			using MemoryStream memoryStream = new MemoryStream();
			XmlSerializer xmlSerializer = new XmlSerializer(subject.GetType());
			xmlSerializer.Serialize(memoryStream, subject);
			memoryStream.Position = 0L;
			return xmlSerializer.Deserialize(memoryStream);
		}
	}
}

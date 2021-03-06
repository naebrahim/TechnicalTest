// <copyright file="PeopleTest.cs">Copyright ©  2017</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechnicalTest;

namespace TechnicalTest.Tests
{
    /// <summary>This class contains parameterized unit tests for People</summary>
    [PexClass(typeof(People))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class PeopleTest
    {
    }
}

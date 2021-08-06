// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SynchronizerTest.cs" company="OBeautifulCode">
//   Copyright (c) OBeautifulCode 2018. All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace OBeautifulCode.Execution.Recipes.Test
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using FakeItEasy;
    using OBeautifulCode.Assertion.Recipes;

    using Xunit;

    public static class SynchronizerTest
    {
        [Fact]
        public static void Run___Should_throw_ArgumentNullException___When_parameter_method_is_null()
        {
            // Arrange
            var systemUnderTest = new Synchronizer();

            // Act
            var actual = Record.Exception(() => systemUnderTest.Run(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Run___Should_block_execution_of_all_other_callers___When_called()
        {
            // Arrange
            var systemUnderTest = new Synchronizer();

            // Act, Assert
            var state = 0;

            var blockingMethodStateIncrement = A.Dummy<int>();

            var blockedMethodsStateIncrement = A.Dummy<int>();

            ThreadPool.QueueUserWorkItem(
                _ =>
                {
                    systemUnderTest.Run(() =>
                    {
                        state += blockingMethodStateIncrement;

                        Thread.Sleep(6000);

                        state.AsTest().Must().BeEqualTo(blockingMethodStateIncrement);
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                _ =>
                {
                    systemUnderTest.Run(() =>
                    {
                        state += blockedMethodsStateIncrement;

                        return true;
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                async _ =>
                {
                    await systemUnderTest.RunAsync(async () =>
                    {
                        state += blockedMethodsStateIncrement;

                        await Task.FromResult(0);
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                async _ =>
                {
                    await systemUnderTest.RunAsync(async () =>
                    {
                        state += blockedMethodsStateIncrement;

                        await Task.FromResult(0);

                        return true;
                    });
                }, null);

            while (state != (blockingMethodStateIncrement + (3 * blockedMethodsStateIncrement)))
            {
                Thread.Sleep(50);
            }
        }

        [Fact]
        public static void Run_T___Should_throw_ArgumentNullException___When_parameter_method_is_null()
        {
            // Arrange
            var systemUnderTest = new Synchronizer();

            // Act
            var actual = Record.Exception(() => systemUnderTest.Run<bool>(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void Run_T___Should_block_execution_of_all_other_callers___When_called()
        {
            // Arrange
            var systemUnderTest = new Synchronizer();

            // Act, Assert
            var state = 0;

            var blockingMethodStateIncrement = A.Dummy<int>();

            var blockedMethodsStateIncrement = A.Dummy<int>();

            ThreadPool.QueueUserWorkItem(
                _ =>
                {
                    systemUnderTest.Run(() =>
                    {
                        state += blockingMethodStateIncrement;

                        Thread.Sleep(6000);

                        state.AsTest().Must().BeEqualTo(blockingMethodStateIncrement);

                        return true;
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                _ =>
                {
                    systemUnderTest.Run(() =>
                    {
                        state += blockedMethodsStateIncrement;
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                async _ =>
                {
                    await systemUnderTest.RunAsync(async () =>
                    {
                        state += blockedMethodsStateIncrement;

                        await Task.FromResult(0);
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                async _ =>
                {
                    await systemUnderTest.RunAsync(async () =>
                    {
                        state += blockedMethodsStateIncrement;

                        await Task.FromResult(0);

                        return true;
                    });
                }, null);

            while (state != (blockingMethodStateIncrement + (3 * blockedMethodsStateIncrement)))
            {
                Thread.Sleep(50);
            }
        }

        [Fact]
        public static async Task RunAsync___Should_throw_ArgumentNullException___When_parameter_method_is_null()
        {
            // Arrange
            var systemUnderTest = new Synchronizer();

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.RunAsync(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void RunAsync___Should_block_execution_of_all_other_callers___When_called()
        {
            // Arrange
            var systemUnderTest = new Synchronizer();

            // Act, Assert
            var state = 0;

            var blockingMethodStateIncrement = A.Dummy<int>();

            var blockedMethodsStateIncrement = A.Dummy<int>();

            ThreadPool.QueueUserWorkItem(
                async _ =>
                {
                    await systemUnderTest.RunAsync(async () =>
                    {
                        state += blockingMethodStateIncrement;

                        Thread.Sleep(6000);

                        state.AsTest().Must().BeEqualTo(blockingMethodStateIncrement);

                        await Task.FromResult(0);
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                _ =>
                {
                    systemUnderTest.Run(() =>
                    {
                        state += blockedMethodsStateIncrement;
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                _ =>
                {
                    systemUnderTest.Run(() =>
                    {
                        state += blockedMethodsStateIncrement;

                        return true;
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                async _ =>
                {
                    await systemUnderTest.RunAsync(async () =>
                    {
                        state += blockedMethodsStateIncrement;

                        await Task.FromResult(0);

                        return true;
                    });
                }, null);

            while (state != (blockingMethodStateIncrement + (3 * blockedMethodsStateIncrement)))
            {
                Thread.Sleep(50);
            }
        }

        [Fact]
        public static async Task RunAsync_T___Should_throw_ArgumentNullException___When_parameter_method_is_null()
        {
            // Arrange
            var systemUnderTest = new Synchronizer();

            // Act
            var actual = await Record.ExceptionAsync(() => systemUnderTest.RunAsync<bool>(null));

            // Assert
            actual.AsTest().Must().BeOfType<ArgumentNullException>();
        }

        [Fact]
        public static void RunAsync_T___Should_block_execution_of_all_other_callers___When_called()
        {
            // Arrange
            var systemUnderTest = new Synchronizer();

            // Act, Assert
            var state = 0;

            var blockingMethodStateIncrement = A.Dummy<int>();

            var blockedMethodsStateIncrement = A.Dummy<int>();

            ThreadPool.QueueUserWorkItem(
                async _ =>
                {
                    await systemUnderTest.RunAsync(async () =>
                    {
                        state += blockingMethodStateIncrement;

                        Thread.Sleep(6000);

                        state.AsTest().Must().BeEqualTo(blockingMethodStateIncrement);

                        await Task.FromResult(0);

                        return true;
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                _ =>
                {
                    systemUnderTest.Run(() =>
                    {
                        state += blockedMethodsStateIncrement;
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                _ =>
                {
                    systemUnderTest.Run(() =>
                    {
                        state += blockedMethodsStateIncrement;

                        return true;
                    });
                }, null);

            Thread.Sleep(500);

            ThreadPool.QueueUserWorkItem(
                async _ =>
                {
                    await systemUnderTest.RunAsync(async () =>
                    {
                        state += blockedMethodsStateIncrement;

                        await Task.FromResult(0);
                    });
                }, null);

            while (state != (blockingMethodStateIncrement + (3 * blockedMethodsStateIncrement)))
            {
                Thread.Sleep(50);
            }
        }
    }
}
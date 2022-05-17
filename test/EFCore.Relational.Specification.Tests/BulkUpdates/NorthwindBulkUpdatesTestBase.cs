// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using Microsoft.EntityFrameworkCore.TestModels.Northwind;

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public abstract class NorthwindBulkUpdatesTestBase<TFixture> : BulkUpdatesTestBase<TFixture>
    where TFixture : NorthwindQueryRelationalFixture<NoopModelCustomizer>, new()
{
    protected NorthwindBulkUpdatesTestBase(TFixture fixture)
        : base(fixture)
    {
    }

    [ConditionalTheory]
    [MemberData(nameof(IsAsyncData))]
    public virtual Task Where_delete(bool async)
        => AssertDelete(
            async,
            ss => ss.Set<OrderDetail>().Where(e => e.OrderID < 10300),
            rowsAffectedCount: 140);

    protected virtual void ClearLog()
        => Fixture.TestSqlLoggerFactory.Clear();
}

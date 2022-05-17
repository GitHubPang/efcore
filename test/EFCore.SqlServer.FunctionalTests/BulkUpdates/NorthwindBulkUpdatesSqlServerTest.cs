// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

namespace Microsoft.EntityFrameworkCore.BulkUpdates;

public class NorthwindBulkUpdatesSqlServerTest : NorthwindBulkUpdatesTestBase<NorthwindQuerySqlServerFixture<NoopModelCustomizer>>
{
    public NorthwindBulkUpdatesSqlServerTest(NorthwindQuerySqlServerFixture<NoopModelCustomizer> fixture)
        : base(fixture)
    {
        ClearLog();
    }

    public override async Task Where_delete(bool async)
    {
        await base.Where_delete(async);

        AssertSql(
            @"DELETE FROM [o]
FROM [Order Details] AS [o]
WHERE [o].[OrderID] < 10300");
    }

    private void AssertSql(params string[] expected)
        => Fixture.TestSqlLoggerFactory.AssertBaseline(expected);
}

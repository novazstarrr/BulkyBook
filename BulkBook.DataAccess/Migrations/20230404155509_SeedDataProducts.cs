using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BulkyBookWeb.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 1, "Cashmere Merino Silk - China Blue", "<p>Ultra Lace 2 Ply in China Blue; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793011411_e1e3877693_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 2, "Cashmere Merino Silk - Burgundy", "<p>Ultra Lace 2 Ply in Burgundy; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793455283_552e38c506_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 3, "Cashmere Merino Silk - Soft Pink", "<p>Ultra Lace 2 Ply in Soft Pink; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793402330_aac55090b6_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 4, "Cashmere Merino Silk - Silver Grey", "<p>Ultra Lace 2 Ply in Silver Grey; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793455308_42e9133d59_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 5, "Cashmere Merino Silk - Saddle Brow", "<p>Ultra Lace 2 Ply in Saddle Brown; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793455328_ef5b7f6ef8_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 6, "Cashmere Merino Silk - Royal Navy", "<p>Ultra Lace 2 Ply in Royal Navy; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793249099_16bb03acba_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 7, "Cashmere Merino Silk - Riding Red", "<p>Ultra Lace 2 Ply in Riding Red; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52792452432_ffd2edfc87_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 8, "Cashmere Merino Silk - Regency Blue", "<p>Ultra Lace 2 Ply in Regency Blue; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793249129_b466c7cf1d_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 9, "Cashmere Merino Silk - Polished Copper", "<p>Ultra Lace 2 Ply in Polished Copper; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793009221_2c9301e048_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 10, "Cashmere Merino Silk - Orient Blue", "<p>Ultra Lace 2 Ply in Orient Blue; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52792452492_8dd9ab0cd5_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 11, "Cashmere Merino Silk - Orchard Red", "<p>Ultra Lace 2 Ply in Orchard Red; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52792452527_37bf452e5f_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 12, "Cashmere Merino Silk - Nomad Orange", "<p>Ultra Lace 2 Ply in Nomad Orange; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793402495_5b4646d441_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 13, "Cashmere Merino Silk - Mother Of Pearl", "<p>Ultra Lace 2 Ply in Mother Of Pearl; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793249199_3b8e2f0cfd_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 14, "Cashmere Merino Silk - Morning Yellow", "<p>Ultra Lace 2 Ply in Morning Yellow; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52792452607_78bc500319_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 15, "Cashmere Merino Silk - Livery Tan", "<p>Ultra Lace 2 Ply in Livery Tan; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793009321_6415b8fd82_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 16, "Cashmere Merino Silk - Lilac Blossom", "<p>Ultra Lace 2 Ply in Lilac Blossom; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52792452662_c886200a2f_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 17, "Cashmere Merino Silk - English Rose", "<p>Ultra Lace 2 Ply in English Rose; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793009341_c26cb8ab9b_w.jpg", 1, 1 }
                );

            migrationBuilder.InsertData(

                table: "Products",
                columns: new[] { "Id", "Title", "Description", "Weight", "Author", "ListPrice", "Price", "Price50", "Price100", "ImageUrl", "CategoryId", "CoverTypeId" },
                values: new object[] { 18, "Cashmere Merino Silk - Downtown Violet", "<p>Ultra Lace 2 Ply in Downtown Violet; 194m : 218 yds / 50g ~ &pound;10<br><br>Sirdar's 2 Ply Ultra double knitting Lace is woollen spun from a blend of fine Shetland wool with Lambswool. This weight of yarn was originally used in Shetland Lace haps, but is also perfect for light treasured garments such as shawls, scarves, wraps and summer sweaters because of its wonderful drape and softness. It can also be used in many vintage patterns which call for \"3 Ply yarns\".<br><br>This favourite designer Shetland Lace yarn is without a doubt a special yarn that only improves when dressed - very inspiring for lace knitters!</p>", "50g", "Sirdar", 10, 10, 10, 10, "https://live.staticflickr.com/65535/52793249274_af7cb394b9_w.jpg", 1, 1 }
                );

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

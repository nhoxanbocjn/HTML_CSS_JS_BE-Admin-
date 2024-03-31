
/*----Hàm tìm kiếm sản phẩm--- */
/*---Phân biệt dấu---*/
{
    $(document).ready(function () {
        $('.form-searchbox').submit(function (event) {
            event.preventDefault(); // Ngăn form submit mặc định

            var searchTerm = removeAccents($('#search-landscape').val().toLowerCase().trim()); // Chuẩn hóa và chuyển đổi từ khóa tìm kiếm sang chữ thường

            $('.product-item').each(function () {
                var productTitle = removeAccents($(this).find('.item-title a').text().toLowerCase().trim()); // Chuẩn hóa và chuyển đổi tiêu đề sản phẩm sang chữ thường

                // Kiểm tra xem từ khóa tìm kiếm có xuất hiện trong tiêu đề sản phẩm hay không
                if (productTitle.includes(searchTerm)) {
                    $(this).show(); // Hiển thị sản phẩm nếu có kết quả tìm kiếm
                } else {
                    $(this).hide(); // Ẩn sản phẩm nếu không có kết quả tìm kiếm
                }
            });
        });
    });
    // Hàm loại bỏ dấu và chuẩn hóa ký tự
    function removeAccents(str) {
        return str.normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/\s+/g, ''); // Loại bỏ dấu và khoảng trắng
    }
}
/*---Không phân biệt dấu---*/
   /* $(document).ready(function () {
        // Bắt sự kiện submit của form 
        $('.form-searchbox').submit(function (event) {
            event.preventDefault(); // Ngăn form submit mặc định

            var searchTerm = removeAccents($('#search-landscape').val().toLowerCase().trim()); // Lấy từ khóa tìm kiếm, loại bỏ dấu và khoảng trắng, chuyển đổi sang chữ thường

            $('.product-item').each(function () {
                var productTitle = removeAccents($(this).find('.item-title a').text().toLowerCase().trim()); // Lấy tiêu đề sản phẩm, loại bỏ dấu và khoảng trắng, chuyển đổi sang chữ thường

                // Kiểm tra xem từ khóa tìm kiếm có xuất hiện trong tiêu đề sản phẩm hay không
                if (productTitle.includes(searchTerm)) {
                    $(this).show(); // Hiển thị sản phẩm nếu có kết quả tìm kiếm
                } else {
                    $(this).hide(); // Ẩn sản phẩm nếu không có kết quả tìm kiếm
                }
            });
        });
        });

    // Hàm loại bỏ dấu và khoảng trắng
    function removeAccents(str) {
            //return str.normalize("NFD").replace(/[\u0300-\u036f]/g, "").replace(/\s+/g, ''); // Loại bỏ dấu và khoảng trắng
            var AccentsMap = [
    "aàảãáạăằẳẵắặâầẩẫấậ",
    "AÀẢÃÁẠĂẰẲẴẮẶÂẦẨẪẤẬ",
    "dđ", "DĐ",
    "eèẻẽéẹêềểễếệ",
    "EÈẺẼÉẸÊỀỂỄẾỆ",
    "iìỉĩíị",
    "IÌỈĨÍỊ",
    "oòỏõóọôồổỗốộơờởỡớợ",
    "OÒỎÕÓỌÔỒỔỖỐỘƠỜỞỠỚỢ",
    "uùủũúụưừửữứự",
    "UÙỦŨÚỤƯỪỬỮỨỰ",
    "yỳỷỹýỵ",
    "YỲỶỸÝỴ"
    ];
    for (var i = 0; i < AccentsMap.length; i++) {
                var re = new RegExp('[' + AccentsMap[i] + ']', 'g');
    var char = AccentsMap[i][0];
    str = str.replace(re, char);
            }

    return str;
        }
/* */

$(document).ready(function () {
    // Bắt sự kiện submit của form có id="timkiem1"
    $('#timkiem1').submit(function (event) {
        event.preventDefault(); // Ngăn form submit mặc định

        var searchTerm = removeAccents($('#search-landscape1').val().toLowerCase().trim()); // Lấy từ khóa tìm kiếm, loại bỏ dấu và khoảng trắng, chuyển đổi sang chữ thường

        $('.product-item').each(function () {
            var productTitle = removeAccents($(this).find('.item-title a').text().toLowerCase().trim()); // Lấy tiêu đề sản phẩm, loại bỏ dấu và khoảng trắng, chuyển đổi sang chữ thường

            // Kiểm tra xem từ khóa tìm kiếm có xuất hiện trong tiêu đề sản phẩm hay không
            if (productTitle.includes(searchTerm)) {
                $(this).show(); // Hiển thị sản phẩm nếu có kết quả tìm kiếm
            } else {
                $(this).hide(); // Ẩn sản phẩm nếu không có kết quả tìm kiếm
            }
        });
    });
});
/*---Hàm ẩn/hiển danh mục sản phẩm con---*/
{
    function toggleDropdown(category) {
        var categoryList = document.getElementById(category + '-list');
        if (categoryList) {
            categoryList.classList.toggle('dropdown-active');
        }
    }
}
/*---Hàm sắp xếp theo giá, số lượt bán---*/
{
    // Lấy giá trị của option được chọn
    var sortBy = document.getElementById("sort-by").value;

    // Lấy danh sách các sản phẩm
    var products = document.querySelectorAll(".product-item");

    // Chuyển danh sách từ NodeList thành mảng để dễ sử dụng
    var productList = Array.from(products);

    // Hàm sắp xếp các sản phẩm theo giá từ thấp đến cao
    function sortByPriceLowToHigh(a, b) {
        var priceA = parseFloat(a.querySelector(".item-new-price").textContent.replace(/\D/g, ''));
        var priceB = parseFloat(b.querySelector(".item-new-price").textContent.replace(/\D/g, ''));
        return priceA - priceB;
    }

    // Hàm sắp xếp các sản phẩm theo giá từ cao đến thấp
    function sortByPriceHighToLow(a, b) {
        var priceA = parseFloat(a.querySelector(".item-new-price").textContent.replace(/\D/g, ''));
        var priceB = parseFloat(b.querySelector(".item-new-price").textContent.replace(/\D/g, ''));
        return priceB - priceA;
    }
    //Sắp xếp theo số lượt bán
    function sortBySalesHighToLow(a, b) {
        var salesA = parseInt(a.querySelector(".data-sales").innerText); // Lấy số lượt bán từ phần tử con có class là data-sales và chuyển thành số nguyên
        var salesB = parseInt(b.querySelector(".data-sales").innerText); // Lấy số lượt bán từ phần tử con có class là data-sales và chuyển thành số nguyên
        return salesB - salesA;
    }
   
    // Xử lý sự kiện khi chọn một tùy chọn mới từ dropdown
    document.getElementById("sort-by").addEventListener("change", function () {
        // Lấy giá trị được chọn
        var sortBy = this.value;

        // Kiểm tra nếu giá trị được chọn là "no-sort"
        if (sortBy === "no-sort") {
            // Gán lại danh sách sản phẩm ban đầu vào productList
            productList = Array.from(products);
        } else {
            // Sắp xếp danh sách sản phẩm dựa trên giá và số lượt bán
            if (sortBy === "price_low_to_high") {
                productList.sort(sortByPriceLowToHigh);
            } else if (sortBy === "price_high_to_low") {
                productList.sort(sortByPriceHighToLow);
            } else if (sortBy === "sales_high_to_low") {
                productList.sort(sortBySalesHighToLow);
            }
        }
        // Xóa các sản phẩm hiện tại ra khỏi container
        var productContainer = document.querySelector(".product-container");
        productContainer.innerHTML = "";
        // Đưa các sản phẩm đã được sắp xếp vào container
        productList.forEach(function (product) {
            productContainer.appendChild(product);
        });
    });
}

/*---Hàm để lọc sản phẩm trong khoảng giá được nhập vào--- */
{
    function filterProductsByPrice() {
        // Lấy giá trị được nhập vào từ ô input "Giá tối thiểu"
        var minPrice = parseFloat(document.getElementById("min-price").value);

        // Lấy giá trị được nhập vào từ ô input "Giá tối đa"
        var maxPrice = parseFloat(document.getElementById("max-price").value);

        // Lấy danh sách các sản phẩm
        var products = document.querySelectorAll(".product-item");

        // Duyệt qua từng sản phẩm và ẩn hoặc hiển thị tùy thuộc vào giá của sản phẩm
        products.forEach(function (product) {
            var priceString = product.querySelector(".item-new-price").textContent;
            var price = parseFloat(priceString.replace(/\D/g, '')); // Chuyển đổi giá sang dạng số

            if ((isNaN(minPrice) || price >= minPrice) && (isNaN(maxPrice) || price <= maxPrice)) {
                // Hiển thị sản phẩm nếu giá nằm trong khoảng hoặc không nhập giá tối thiểu hoặc tối đa
                product.style.display = "block";
            } else {
                // Ẩn sản phẩm nếu giá không nằm trong khoảng
                product.style.display = "none";
            }
        });
    }
    // Gọi hàm filterProductsByPrice khi người dùng nhấn nút "Lọc"
    document.getElementById("filter-btn").addEventListener("click", filterProductsByPrice);
}

/*---Hàm để reset lại tất cả bộ lọc và hiển thị lại danh sách sản phẩm ban đầu---*/
{
const productLineCheckboxes = document.querySelectorAll('input[type="checkbox"][class="check-box"]');

// Lấy giá trị ô input "Giá tối thiểu"
const minPriceInput = document.getElementById("min-price");

// Lấy giá trị ô input "Giá tối đa"
const maxPriceInput = document.getElementById("max-price");

// Hàm xóa bộ lọc và hiển thị lại danh sách sản phẩm ban đầu
const clearFilters = () => {
    // Bỏ chọn tất cả checkbox dòng sản phẩm
    productLineCheckboxes.forEach(checkbox => {
        checkbox.checked = false;
    });

    // Xóa giá trị ô input "Giá tối thiểu"
    minPriceInput.value = "";

    // Xóa giá trị ô input "Giá tối đa"
    maxPriceInput.value = "";

    // Hiển thị lại toàn bộ sản phẩm
    const productItems = document.querySelectorAll('.product-item');
    productItems.forEach(item => {
        item.style.display = 'block';
    });
};

// Lắng nghe sự kiện click trên nút "Xóa bộ lọc"
document.getElementById("clear-filter-btn").addEventListener("click", clearFilters);
}

/*---Hàm lọc sản phẩm thuộc hãng sản xuất hoặc trạng thái hoặc cấu hình theo mức giá---*/
{
    // Lấy danh sách các checkbox dòng sản phẩm
    const productLineCheckboxes = document.querySelectorAll('input[type="checkbox"][class="check-box"]');

    // Lọc sản phẩm dựa trên giá trị checkbox đã chọn và khoảng giá nhập vào
    const filterProducts = () => {
        // Lấy giá trị của checkbox dòng sản phẩm đã được chọn
        const selectedProductLines = Array.from(productLineCheckboxes)
            .filter(checkbox => checkbox.checked)
            .map(checkbox => checkbox.value);

        // Lấy giá trị được nhập vào từ ô input "Giá tối thiểu"
        const minPrice = parseFloat(document.getElementById("min-price").value);

        // Lấy giá trị được nhập vào từ ô input "Giá tối đa"
        const maxPrice = parseFloat(document.getElementById("max-price").value);

        // Lọc và hiển thị sản phẩm dựa trên giá trị checkbox và khoảng giá nhập vào
        const productItems = document.querySelectorAll('.product-item');
        productItems.forEach(item => {
            // Lấy tiêu đề và tag của sản phẩm
            const itemTitle = item.querySelector('.item-title');
            const itemTags = item.querySelectorAll('.tag');

            // Kiểm tra nếu tiêu đề hoặc tag của sản phẩm chứa giá trị của checkbox đã chọn
            const containsSelectedLines = selectedProductLines.some(line => {
                const lineLowerCase = line.toLowerCase();
                const titleText = itemTitle ? itemTitle.textContent.toLowerCase() : '';
                const tagTexts = Array.from(itemTags).map(tag => tag.textContent.trim().toLowerCase());
                return titleText.includes(lineLowerCase) || tagTexts.includes(lineLowerCase);
            });

            // Lấy giá của sản phẩm
            const priceString = item.querySelector('.item-new-price').textContent;
            const price = parseFloat(priceString.replace(/\D/g, '')); // Chuyển đổi giá sang dạng số

            // Kiểm tra nếu sản phẩm nằm trong khoảng giá hoặc không có giá trị nhập vào
            const withinPriceRange = (isNaN(minPrice) || price >= minPrice) && (isNaN(maxPrice) || price <= maxPrice);

            // Hiển thị hoặc ẩn sản phẩm tương ứng dựa trên cả checkbox và khoảng giá
            item.style.display = containsSelectedLines && withinPriceRange ? 'block' : 'none';
        });
    };

    // Lắng nghe sự kiện thay đổi trên checkbox dòng sản phẩm
    productLineCheckboxes.forEach(checkbox => {
        checkbox.addEventListener('change', filterProducts);
    });

    // Gọi hàm filterProductsByPrice khi người dùng nhấn nút "Lọc"
    document.getElementById("filter-btn").addEventListener("click", filterProducts);
}

/*---Hàm lọc theo số sao đánh giá---*/
{
    const productLineCheckboxes = document.querySelectorAll('input[type="checkbox"][class="check-box"]');

    // Lấy giá trị ô input "Giá tối thiểu"
    const minPriceInput = document.getElementById("min-price");

    // Lấy giá trị ô input "Giá tối đa"
    const maxPriceInput = document.getElementById("max-price");

    document.addEventListener('DOMContentLoaded', function () {
        // Lấy tất cả các nút lọc đánh giá sao
        const ratingButtons = document.querySelectorAll('.facet-link');
        
        // Lắng nghe sự kiện click cho mỗi nút
        ratingButtons.forEach(function (button) {
            button.addEventListener('click', function () {
                
                    // Bỏ chọn tất cả checkbox dòng sản phẩm
                    productLineCheckboxes.forEach(checkbox => {
                        checkbox.checked = false;
                    });

                    // Xóa giá trị ô input "Giá tối thiểu"
                    minPriceInput.value = "";

                    // Xóa giá trị ô input "Giá tối đa"
                    maxPriceInput.value = "";
                
                // Lấy độ rộng của sao từ thuộc tính data-rating
                const rating = parseInt(button.getAttribute('data-rating'));

                // Lọc sản phẩm dựa trên độ rộng của sao
                const productItems = document.querySelectorAll('.product-item');
                productItems.forEach(function (item) {
                    const stars = item.querySelector('.star span');
                    if (stars) {
                        // Lấy độ rộng của sao từ style width (vd: "width: 76px")
                        const starWidth = parseInt(stars.style.width);
                        // Nếu độ rộng sao lớn hơn hoặc bằng đánh giá được chọn, hiển thị sản phẩm
                        if (starWidth >= rating * 15) {
                            item.style.display = 'block';
                        } else {
                            item.style.display = 'none';
                        }
                    }
                });
            });
        });
    });
}

/** */
{

}
/*---Hàm để lọc sản phẩm trong khoảng giá được nhập vào--- */
{
    function filterProductsByPrice() {
        // Lấy giá trị được nhập vào từ ô input "Giá tối thiểu"
        var minPrice = parseFloat(document.getElementById("min-price").value);

        // Lấy giá trị được nhập vào từ ô input "Giá tối đa"
        var maxPrice = parseFloat(document.getElementById("max-price").value);

        // Lấy danh sách các sản phẩm
        var products = document.querySelectorAll(".product-item");

        // Duyệt qua từng sản phẩm và ẩn hoặc hiển thị tùy thuộc vào giá của sản phẩm
        products.forEach(function (product) {
            var priceString = product.querySelector(".item-new-price").textContent;
            var price = parseFloat(priceString.replace(/\D/g, '')); // Chuyển đổi giá sang dạng số

            if ((isNaN(minPrice) || price >= minPrice) && (isNaN(maxPrice) || price <= maxPrice)) {
                // Hiển thị sản phẩm nếu giá nằm trong khoảng hoặc không nhập giá tối thiểu hoặc tối đa
                product.style.display = "block";
            } else {
                // Ẩn sản phẩm nếu giá không nằm trong khoảng
                product.style.display = "none";
            }
        });
    }
    // Gọi hàm filterProductsByPrice khi người dùng nhấn nút "Lọc"
    document.getElementById("filter-btn").addEventListener("click", filterProductsByPrice);
}

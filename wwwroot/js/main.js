function taoCard(s) {
    return '<div class="book-card">' +
        '<a href="#"><img src="/images/' + s.anh + '" alt="' + s.tenSach + '"/></a>' +
        '<h2>' + s.tenSach + '</h2>' +
        '<div class="book-foot"><span class="price">' + s.gia + '</span>' +
        '<button class="btn-huy" type="button">Them vao gio</button></div>' +
        '</div>';
}

$(function () {
    $(window).on('scroll', function () {
        $('.to-top').toggle($(this).scrollTop() > 200);
    });

    $('.to-top').on('click', function () {
        $('html, body').animate({ scrollTop: 0 }, 400);
    });

    $(document).on('click', '.category-link', function (e) {
        e.preventDefault();

        var $a = $(this);
        var id = $a.data('matl');
        var ten = $a.data('tentl') || $a.text().trim();

        $('#tieu-de').text(ten);
        $('.menu li').removeClass('active');
        $a.closest('li').addClass('active');

        $.ajax({
            url: '/Home/LocTheoTheLoai/' + id,
            type: 'GET',
            dataType: 'json',
            success: function (res) {
                $('#ds-sach').html(
                    res.sach.length ? res.sach.map(taoCard).join('') : '<p class="empty">The loai nay chua co sach >= 100k</p>'

                );
            },
            error: function () {
                alert('Khong tai duoc du lieu the loai.');
            }
        });
    });

    $(document).on('click', '.home-link', function (e) {
        e.preventDefault();
        window.location.href = '/Home/Index';
    });
});


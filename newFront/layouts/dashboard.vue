<template>
  <div class="min-h-screen bg-gray-100">
    <DashAside :navItems="navItems" />

    <div class="mr-64">
      <DashHeader />

      <main class="p-8">
        <slot />
      </main>
    </div>
  </div>
</template>

<script setup>
const navItems = [
  {
    name: "الرئيسية",
    path: "/dashboard",
  },
  {
    name: "المنتجات",
    path: "/dashboard/products",
  },
  {
    name: "المستخدمين",
    path: "/dashboard",
  },
  {
    name: "الإعدادات",
    path: "/dashboard",
  },
  {
    name: "التقارير",
    path: "/dashboard",
  },
];
</script>
